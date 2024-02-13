using Kitchen.UseCases.Configurations.Commands;

namespace Kitchen.UseCases.Commands.FoodPrices.DeleteFoodPrice
{
    public record DeleteFoodPriceCommand(string Id) : ICommand;
}
