using Kitchen.Domain.Entities;

namespace Kitchen.UseCases.Interfaces
{
    public interface IFoodRepository : IBaseRepository<Food>
    {
        Task<IReadOnlyList<Food>> GetAllFoods();
        Task<IReadOnlyList<Food>> GetFoodsByCategoryId(Guid categoryId);
        Task<Food?> GetFoodById(Guid id);
    }
}
