using Kitchen.UseCases.Configurations.Queries;

namespace Kitchen.UseCases.Queries.FoodPrices.GetFoodPricesByFoodId
{
    public record GetFoodPricesByFoodIdQuery(string FoodId) : IQuery<IReadOnlyList<FoodPriceDto>>;
}
