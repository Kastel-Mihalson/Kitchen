using Kitchen.UseCases.Configurations.Commands;

namespace Kitchen.UseCases.Commands.Projects.UpdateProject
{
    public record UpdateProjectCommand(
        string Id,
        string Name,
        string Description,
        string? Image) : ICommand;
}
