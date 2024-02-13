using Kitchen.UseCases.Configurations.Commands;

namespace Kitchen.UseCases.Commands.Foods.DeleteFood
{
    public record DeleteFoodCommand(string Id) : ICommand;
}
