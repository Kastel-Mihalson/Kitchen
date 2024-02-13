namespace Kitchen.UseCases.Queries.FoodCategories.GetFoodCategory
{
    public record FoodCategoryDto(
        Guid Id,
        DateTime CreationDate,
        string Name,
        string Description,
        Guid ProjectId);
}
