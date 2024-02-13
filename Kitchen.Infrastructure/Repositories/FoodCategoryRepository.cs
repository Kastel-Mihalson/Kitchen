using Kitchen.Domain.Entities;
using Kitchen.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infrastructure.Repositories
{
    public class FoodCategoryRepository : BaseRepository<FoodCategory>, IFoodCategoryRepository
    {
        public FoodCategoryRepository(KitchenDbContext dbContext)
            : base(dbContext) {}

        public async Task<IReadOnlyList<FoodCategory>> GetAllFoodCategories()
        {
            return await GetAll().OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<FoodCategory?> GetFoodCategoryById(Guid id)
        {
            return await GetByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
