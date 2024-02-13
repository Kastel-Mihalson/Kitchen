using Kitchen.UseCases.Configurations.Commands;

namespace Kitchen.UseCases.Commands.Users.UpdateUser
{
    public record UpdateUserCommand(
        Guid Id,
        string Name,
        string Email,
        string Password) : ICommand;
}
