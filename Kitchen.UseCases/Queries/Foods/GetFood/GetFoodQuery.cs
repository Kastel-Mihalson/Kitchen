using Kitchen.UseCases.Configurations.Queries;

namespace Kitchen.UseCases.Queries.Foods.GetFood
{
    public record GetFoodQuery(string Id) : IQuery<FoodDto>;
}
