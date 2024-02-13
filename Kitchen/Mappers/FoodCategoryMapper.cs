using Kitchen.Dto.FoodCategories;
using Kitchen.UseCases.Queries.FoodCategories.GetFoodCategory;

namespace Kitchen.Mappers
{
    public static class FoodCategoryMapper
    {
        public static FoodCategoryResponseDto Map(this FoodCategoryDto foodCategoryDto)
        {
            return new FoodCategoryResponseDto
            {
                Id = foodCategoryDto.Id.ToString(),
                Name = foodCategoryDto.Name,
                Description = foodCategoryDto.Description,
                ProjectId = foodCategoryDto.ProjectId.ToString()
            };
        }

        public static IReadOnlyList<FoodCategoryResponseDto> Map(this IReadOnlyList<FoodCategoryDto> foodCategoryDtos)
        {
            return foodCategoryDtos.Select(Map).ToList();
        }
    }
}
