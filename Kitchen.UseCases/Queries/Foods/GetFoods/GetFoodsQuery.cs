using Kitchen.UseCases.Configurations.Queries;
using Kitchen.UseCases.Queries.Foods.GetFood;

namespace Kitchen.UseCases.Queries.Foods.GetFoods
{
    public record GetFoodsQuery() : IQuery<IReadOnlyList<FoodDto>>;
}
