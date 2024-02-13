using Kitchen.UseCases.Configurations.Queries;
using Kitchen.UseCases.Queries.Projects.GetProject;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infrastructure.Queries.Projects.GetProject
{
    public class GetProjectQueryHandler : IQueryHandler<GetProjectQuery, ProjectDto>
    {
        private readonly KitchenDbContext _context;

        public GetProjectQueryHandler(KitchenDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectDto> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var projectQuery = from p in _context.Projects
                            where p.Id == Guid.Parse(request.Id)
                            select p;

            var project = await projectQuery.FirstOrDefaultAsync();

            if (project is null)
            {
                throw new Exception($"Project with id {request.Id} not found!");
            }

            return new ProjectDto(
                project.Id,
                project.CreationDate,
                project.Name,
                project.Description,
                project.Image);
        }
    }
}
