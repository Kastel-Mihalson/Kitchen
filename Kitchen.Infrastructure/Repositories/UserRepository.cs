using Kitchen.Domain.Entities;
using Kitchen.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(KitchenDbContext dbContext) : base(dbContext) { }

        public async Task<IReadOnlyList<User>> GetAllUsers()
        {
            return await GetAll().OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await GetByCondition(user => user.Email.Equals(email)).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await GetByCondition(user => user.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
