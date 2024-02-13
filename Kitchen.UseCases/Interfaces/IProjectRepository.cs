using Kitchen.Domain.Entities;

namespace Kitchen.UseCases.Interfaces
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<IReadOnlyList<Project>> GetAllProjects();
        Task<Project?> GetProjectById(Guid id);
    }
}
