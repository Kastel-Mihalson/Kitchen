using Kitchen.Domain.Entities;
using Kitchen.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infrastructure.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(KitchenDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Project>> GetAllProjects()
        {
            return await GetAll().OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Project?> GetProjectById(Guid id)
        {
            return await GetByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
