using Kitchen.Domain.Entities;

namespace Kitchen.UseCases.Interfaces
{
    public interface IFoodPriceHistoryRepository : IBaseRepository<FoodPriceHistory>
    {
        Task<IReadOnlyList<FoodPriceHistory>> GetFoodPrices(Guid foodId);

        Task<FoodPriceHistory> GetFoodPriceHistoryById(Guid id);
    }
}
