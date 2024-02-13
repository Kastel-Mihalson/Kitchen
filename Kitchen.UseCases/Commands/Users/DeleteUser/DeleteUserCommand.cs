using Kitchen.UseCases.Configurations.Commands;

namespace Kitchen.UseCases.Commands.Users.DeleteUser
{
    public record DeleteUserCommand(string Id) : ICommand;
}
