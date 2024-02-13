using Kitchen.Domain.Entities;
using Kitchen.Dto.FoodCategories;
using Kitchen.Mappers;
using Kitchen.Models;
using Kitchen.UseCases.Configurations;
using Kitchen.UseCases.Interfaces;
using Kitchen.UseCases.Queries.FoodCategories.GetFoodCategoriesByProjectId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodCategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKitchenModule _kitchenModule;

        public FoodCategoriesController(IUnitOfWork unitOfWork, IKitchenModule kitchenModule)
        {
            _unitOfWork = unitOfWork;
            _kitchenModule = kitchenModule;
        }

        [HttpGet]
        public async Task<IActionResult> GetFoodCategories()
        {
            var categories = await _unitOfWork.FoodCategories.GetAllFoodCategories();

            return Ok(categories);
        }

        [HttpGet("{foodCategoryId}")]
        public async Task<IActionResult> GetFoodCategoryById(string foodCategoryId)
        {
            var foodCategory = await _unitOfWork.FoodCategories
                .GetFoodCategoryById(Guid.Parse(foodCategoryId));

            if (foodCategory is null)
            {
                return NotFound();
            }

            return Ok(foodCategory);
        }

        /// <summary>
        /// Получение списка категорий по идентификатору проекта
        /// </summary>
        [HttpGet("project/{projectId}")]
        [ProducesResponseType(typeof(IReadOnlyList<FoodCategoryResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFoodsCategoryByProjectId(
            string projectId,
            CancellationToken cancellationToken = default)
        {
            var foodCategories = await _kitchenModule.ExecuteQueryAsync(new GetFoodCategoriesByProjectIdQuery(projectId), cancellationToken);
            return Ok(foodCategories.Map());
        }

        [HttpPost]
        public async Task<IActionResult> CreateFoodCategory(
            [FromBody] FoodCategoryData data)
        {
            var foodCategoryId = Guid.NewGuid();

            _unitOfWork.FoodCategories.Create(new FoodCategory
            {
                Id = foodCategoryId,
                Name = data.Name,
                Description = data.Description,
                ProjectId = Guid.Parse(data.ProjectId)
            });

            await _unitOfWork.SaveAsync();

            return Ok(new { foodCategoryId = foodCategoryId });
        }

        [HttpPut("{foodCategoryId}")]
        public async Task<IActionResult> UpdateFoodCategory(
            [FromBody] FoodCategoryData data,
            string foodCategoryId)
        {
            var foodCategory = await _unitOfWork.FoodCategories
                .GetFoodCategoryById(Guid.Parse(foodCategoryId));

            if (foodCategory is null)
            {
                return NotFound();
            }

            foodCategory.Name = data.Name;

            if (data.Description != null)
            {
                foodCategory.Description = data.Description;
            }

            _unitOfWork.FoodCategories.Update(foodCategory);

            await _unitOfWork.SaveAsync();

            return Ok();
        }

        [HttpDelete("{foodCategoryId}")]
        public async Task<IActionResult> DeleteFoodCategory(string foodCategoryId)
        {
            var foodCategory = await _unitOfWork.FoodCategories
                .GetFoodCategoryById(Guid.Parse(foodCategoryId));

            if (foodCategory is null)
            {
                return BadRequest();
            }

            _unitOfWork.FoodCategories.Delete(foodCategory);

            await _unitOfWork.SaveAsync();

            return Ok();
        }
    }
}
