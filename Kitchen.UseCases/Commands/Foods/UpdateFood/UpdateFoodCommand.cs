using Kitchen.UseCases.Configurations.Commands;

namespace Kitchen.UseCases.Commands.Foods.UpdateFood
{
    public record UpdateFoodCommand(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        string? Image,
        Guid FoodCategoryId,
        Guid ProjectId) : ICommand;
}
