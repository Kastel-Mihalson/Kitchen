using Kitchen.Dto.FoodPrices;
using Kitchen.UseCases.Queries.FoodPrices.GetFoodPricesByFoodId;

namespace Kitchen.Mappers
{
    public static class FoodPriceMapper
    {
        public static FoodPricesResponseDto Map(this FoodPriceDto foodPriceDto)
        {
            return new FoodPricesResponseDto
            {
                Id = foodPriceDto.Id.ToString(),
                CreationDate = foodPriceDto.CreationDate.ToString("dd-MM-yyyy HH:mm:ss"),
                Price = foodPriceDto.Price
            };
        }

        public static IReadOnlyList<FoodPricesResponseDto> Map(this IReadOnlyList<FoodPriceDto> foodPriceDtos)
        {
            return foodPriceDtos.Select(Map).ToList();
        }
    }
}
