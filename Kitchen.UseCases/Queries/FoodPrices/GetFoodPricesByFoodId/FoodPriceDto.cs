namespace Kitchen.UseCases.Queries.FoodPrices.GetFoodPricesByFoodId
{
    public record FoodPriceDto(
        Guid Id,
        DateTime CreationDate,
        decimal Price);
}
