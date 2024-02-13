using Kitchen.UseCases.Configurations.Commands;

namespace Kitchen.UseCases.Commands.Projects.CreateProject
{
    public record CreateProjectCommand(
        string Name,
        string Description,
        string? Image) : ICommand<Guid>;
}
