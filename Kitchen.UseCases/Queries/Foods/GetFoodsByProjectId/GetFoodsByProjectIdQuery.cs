using Kitchen.UseCases.Configurations.Queries;
using Kitchen.UseCases.Queries.Foods.GetFood;

namespace Kitchen.UseCases.Queries.Foods.GetFoodsByProjectId
{
    public record GetFoodsByProjectIdQuery(string ProjectId) : IQuery<IReadOnlyList<FoodDto>>;
}
