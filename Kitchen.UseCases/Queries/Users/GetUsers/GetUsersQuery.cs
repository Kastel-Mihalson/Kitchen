using Kitchen.UseCases.Configurations.Queries;
using Kitchen.UseCases.Queries.Users.GetUser;

namespace Kitchen.UseCases.Queries.Users.GetUsers
{
    public record GetUsersQuery() : IQuery<IReadOnlyList<UserDto>>;
}
