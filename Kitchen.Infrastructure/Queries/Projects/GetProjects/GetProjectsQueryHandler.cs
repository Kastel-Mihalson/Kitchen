using Kitchen.UseCases.Configurations.Queries;
using Kitchen.UseCases.Queries.Projects.GetProject;
using Kitchen.UseCases.Queries.Projects.GetProjects;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infrastructure.Queries.Projects.GetProjects
{
    public class GetProjectsQueryHandler : IQueryHandler<GetProjectsQuery, IReadOnlyList<ProjectDto>>
    {
        private readonly KitchenDbContext _context;

        public GetProjectsQueryHandler(KitchenDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProjectDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var projectsQuery = from p in _context.Projects select p;

            var projects = await projectsQuery.ToListAsync();

            return projects.Select(x => new ProjectDto(
                x.Id,
                x.CreationDate,
                x.Name,
                x.Description,
                x.Image)).ToList();
        }
    }
}
