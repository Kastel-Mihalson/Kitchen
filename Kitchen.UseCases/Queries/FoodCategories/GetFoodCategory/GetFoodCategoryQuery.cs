using Kitchen.UseCases.Configurations.Queries;

namespace Kitchen.UseCases.Queries.FoodCategories.GetFoodCategory
{
    public record GetFoodCategoryQuery() : IQuery<FoodCategoryDto>;
}
