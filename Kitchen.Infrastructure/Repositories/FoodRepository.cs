using Kitchen.Domain.Entities;
using Kitchen.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infrastructure.Repositories
{
    public class FoodRepository : BaseRepository<Food>, IFoodRepository
    {
        public FoodRepository(KitchenDbContext dbContext)
            : base(dbContext) {}

        public async Task<IReadOnlyList<Food>> GetAllFoods()
        {
            return await GetAll().OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Food?> GetFoodById(Guid id)
        {
            return await GetByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Food>> GetFoodsByCategoryId(Guid categoryId)
        {
            return await GetByCondition(x => x.CategoryId.Equals(categoryId))
                .Include(x => x.Category)
                .ToListAsync();
        }
    }
}
