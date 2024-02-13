using Kitchen.Dto.Users;
using Kitchen.Mappers;
using Kitchen.Models;
using Kitchen.UseCases.Commands.Users.DeleteUser;
using Kitchen.UseCases.Commands.Users.UpdateUser;
using Kitchen.UseCases.Configurations;
using Kitchen.UseCases.Queries.Users.GetUser;
using Kitchen.UseCases.Queries.Users.GetUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IKitchenModule _kitchenModule;

        public UsersController(IKitchenModule kitchenModule)
        {
            _kitchenModule = kitchenModule;
        }

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<UserResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers(
            CancellationToken cancellationToken = default)
        {
            var users = await _kitchenModule.ExecuteQueryAsync(new GetUsersQuery(), cancellationToken);
            return Ok(users.Map());
        }

        /// <summary>
        /// Получение пользователя по идентификатору
        /// </summary>
        [HttpGet("id/{userId}")]
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser(string userId, CancellationToken cancellationToken = default)
        {
            var user = await _kitchenModule.ExecuteQueryAsync(new GetUserQuery(userId), cancellationToken);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user.Map());
        }

        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        [HttpPut("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser(
            [FromBody] UserUpdateData data,
            string userId,
            CancellationToken cancellationToken = default)
        {
            await _kitchenModule.ExecuteCommandAsync(new UpdateUserCommand(
                Guid.Parse(userId),
                data.Name,
                data.Email,
                data.Password), cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser(string userId, CancellationToken cancellationToken = default)
        {
            await _kitchenModule.ExecuteCommandAsync(new DeleteUserCommand(userId), cancellationToken);
            return Ok();
        }
    }
}
