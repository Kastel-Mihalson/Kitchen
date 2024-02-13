using Kitchen.UseCases.Configurations.Queries;
using Kitchen.UseCases.Queries.FoodCategories.GetFoodCategory;

namespace Kitchen.UseCases.Queries.FoodCategories.GetFoodCategoriesByProjectId
{
    public record GetFoodCategoriesByProjectIdQuery(string ProjectId) : IQuery<IReadOnlyList<FoodCategoryDto>>;
}
