using Kitchen.Domain.Entities;
using Kitchen.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infrastructure.Repositories
{
    public class FoodPriceHistoryRepository : BaseRepository<FoodPriceHistory>, IFoodPriceHistoryRepository
    {
        public FoodPriceHistoryRepository(KitchenDbContext dbContext)
            : base(dbContext) {}

        public async Task<IReadOnlyList<FoodPriceHistory>> GetFoodPrices(Guid foodId)
        {
            return await GetByCondition(x => x.FoodId.Equals(foodId)).OrderByDescending(x => x.CreationDate).ToListAsync();
        }

        public async Task<FoodPriceHistory?> GetFoodPriceHistoryById(Guid id)
        {
            return await GetByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
