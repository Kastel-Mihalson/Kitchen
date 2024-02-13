using Kitchen.Common;
using Kitchen.Domain.Entities;
using Kitchen.Common.Utils;
using Kitchen.Models;
using Kitchen.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Kitchen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOptions<AuthOptions> _authOptions;
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(IOptions<AuthOptions> authOptions, IUnitOfWork unitOfWork)
        {
            _authOptions = authOptions;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var user = await AuthentificateUser(login.Email, login.Password);

            if (user is not null)
            {
                return Ok(new { access_token = GenerateJWT(user) });
            }

            return Unauthorized();
        }

        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserData userData)
        {
            var user = await AuthentificateUser(userData.Email, userData.Password);

            if (user is not null)
            {
                return BadRequest();
            }

            Guid userId = Guid.NewGuid();

            _unitOfWork.Users.Create(new User
            {
                Id = userId,
                Email = userData.Email,
                Name = userData.Name,
                Password = PasswordHashingManager.HashPassword(userData.Password)
            });

            await _unitOfWork.SaveAsync();

            return Ok(new { userId = userId });
        }

        /// <summary>
        /// Проверка данных пользователя
        /// </summary>
        private async Task<User?> AuthentificateUser(string email, string password)
        {
            var user = await _unitOfWork.Users.GetUserByEmail(email);

            if (user is null)
            {
                return null;
            }

            var isUserPasswordVerified = PasswordHashingManager.VerifyPassword(password, user.Password);

            return isUserPasswordVerified ? user : null;
        }

        /// <summary>
        /// Генерация JWT токена
        /// </summary>
        private string GenerateJWT(User user)
        {
            var authParams = _authOptions.Value;
            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TimeSpan.FromSeconds(authParams.TokenLifetime)),
                Issuer = authParams.Issuer,
                Audience = authParams.Audience,
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
