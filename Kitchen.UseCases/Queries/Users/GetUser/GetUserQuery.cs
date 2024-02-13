using Kitchen.UseCases.Configurations.Queries;

namespace Kitchen.UseCases.Queries.Users.GetUser
{
    public record GetUserQuery(string Id) : IQuery<UserDto>;
}
