using Kitchen.UseCases.Configurations.Queries;
using Kitchen.UseCases.Queries.Projects.GetProject;

namespace Kitchen.UseCases.Queries.Projects.GetProjects
{
    public record GetProjectsQuery() : IQuery<IReadOnlyList<ProjectDto>>;
}
