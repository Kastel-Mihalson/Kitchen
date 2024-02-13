using Kitchen.Domain.Entities;

namespace Kitchen.UseCases.Interfaces
{
    public interface IFoodCategoryRepository : IBaseRepository<FoodCategory>
    {
        Task<IReadOnlyList<FoodCategory>> GetAllFoodCategories();

        Task<FoodCategory?> GetFoodCategoryById(Guid id);
    }
}
