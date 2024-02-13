using Kitchen.Dto.Users;
using Kitchen.UseCases.Queries.Users.GetUser;

namespace Kitchen.Mappers
{
    public static class UserMapper
    {
        public static UserResponseDto Map(this UserDto userDto)
        {
            return new UserResponseDto
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
                CreationDate = userDto.CreationDate
            };
        }

        public static IReadOnlyList<UserResponseDto> Map(this IReadOnlyList<UserDto> usersDto)
        {
            return usersDto.Select( x => Map(x)).ToList();
        }
    }
}
