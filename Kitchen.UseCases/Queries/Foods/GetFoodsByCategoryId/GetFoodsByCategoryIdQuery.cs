using Kitchen.UseCases.Configurations.Queries;
using Kitchen.UseCases.Queries.Foods.GetFood;

namespace Kitchen.UseCases.Queries.Foods.GetFoodsByCategoryId
{
    public record GetFoodsByCategoryIdQuery(string CategoryId) : IQuery<IReadOnlyList<FoodDto>>;
}
