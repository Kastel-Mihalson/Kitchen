using Kitchen.Dto.Foods;
using Kitchen.UseCases.Queries.Foods.GetFood;

namespace Kitchen.Mappers
{
    public static class FoodMapper
    {
        public static FoodResponseDto Map(this FoodDto foodDto)
        {
            return new FoodResponseDto
            {
                Id = foodDto.Id.ToString(),
                Name = foodDto.Name,
                Description = foodDto.Description,
                Price = foodDto.Price,
                CreationDate = foodDto.CreationDate,
                FoodCategoryId = foodDto.FoodCategoryId.ToString(),
                ProjectId = foodDto.ProjectId.ToString(),
                Image = foodDto.Image
            };
        }

        public static IReadOnlyList<FoodResponseDto> Map(this IReadOnlyList<FoodDto> foodDtos)
        {
            return foodDtos.Select(Map).ToList();
        }
    }
}
