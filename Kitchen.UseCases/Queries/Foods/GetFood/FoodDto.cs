namespace Kitchen.UseCases.Queries.Foods.GetFood
{
    public record FoodDto(
        Guid Id,
        DateTime CreationDate,
        string Name,
        string Description,
        decimal Price,
        string? Image,
        Guid FoodCategoryId,
        Guid ProjectId);
}
