using Kitchen.UseCases.Configurations.Commands;

namespace Kitchen.UseCases.Commands.Foods.CreateFood
{
    public record CreateFoodCommand(
        string Name,
        string Description,
        decimal Price,
        string? Image,
        Guid FoodCategoryId,
        Guid ProjectId) : ICommand<Guid>;
}
