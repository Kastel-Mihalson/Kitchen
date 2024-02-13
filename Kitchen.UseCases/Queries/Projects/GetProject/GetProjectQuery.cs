using Kitchen.UseCases.Configurations.Queries;

namespace Kitchen.UseCases.Queries.Projects.GetProject
{
    public record GetProjectQuery(string Id) : IQuery<ProjectDto>;
}
