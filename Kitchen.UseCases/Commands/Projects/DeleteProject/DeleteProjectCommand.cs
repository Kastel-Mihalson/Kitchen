using Kitchen.UseCases.Configurations.Commands;

namespace Kitchen.UseCases.Commands.Projects.DeleteProject
{
    public record DeleteProjectCommand(string Id) : ICommand;
}
