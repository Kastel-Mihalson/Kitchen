using Kitchen.Domain.Entities;
using Kitchen.Dto.Foods;
using Kitchen.Mappers;
using Kitchen.Models;
using Kitchen.UseCases.Commands.Foods.CreateFood;
using Kitchen.UseCases.Commands.Foods.DeleteFood;
using Kitchen.UseCases.Commands.Foods.UpdateFood;
using Kitchen.UseCases.Configurations;
using Kitchen.UseCases.Interfaces;
using Kitchen.UseCases.Queries.Foods.GetFood;
using Kitchen.UseCases.Queries.Foods.GetFoods;
using Kitchen.UseCases.Queries.Foods.GetFoodsByCategoryId;
using Kitchen.UseCases.Queries.Foods.GetFoodsByProjectId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IKitchenModule _kitchenModule;

        public FoodsController(IKitchenModule kitchenModule)
        {
            _kitchenModule = kitchenModule;
        }

        /// <summary>
        /// Получение всех списков блюд
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<FoodResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFoods(CancellationToken cancellationToken = default)
        {
            var foods = await _kitchenModule.ExecuteQueryAsync(new GetFoodsQuery(), cancellationToken);
            return Ok(foods.Map());
        }

        /// <summary>
        /// Получение блюда по идентификатору
        /// </summary>
        [HttpGet("{foodId}")]
        [ProducesResponseType(typeof(FoodResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFood(string foodId, CancellationToken cancellationToken = default)
        {
            var food = await _kitchenModule.ExecuteQueryAsync(new GetFoodQuery(foodId), cancellationToken);

            if (food is null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        /// <summary>
        /// Получение блюд по идентификатору категории
        /// </summary>
        [HttpGet("category/{foodCategoryId}")]
        public async Task<IActionResult> GetFoodsByCategoryId(
            string foodCategoryId,
            CancellationToken cancellationToken = default)
        {
            var foods = await _kitchenModule.ExecuteQueryAsync(new GetFoodsByCategoryIdQuery(foodCategoryId), cancellationToken);
            return Ok(foods.Map());
        }

        /// <summary>
        /// Получение списка блюд по идентификатору проекта
        /// </summary>
        [HttpGet("project/{projectId}")]
        [ProducesResponseType(typeof(IReadOnlyList<FoodResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFoodsByProjectId(
            string projectId,
            CancellationToken cancellationToken = default)
        {
            var foods = await _kitchenModule.ExecuteQueryAsync(new GetFoodsByProjectIdQuery(projectId), cancellationToken);
            return Ok(foods.Map());
        }

        /// <summary>
        /// Создание блюда
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateFood(
            [FromBody] FoodRequestDto data,
            CancellationToken cancellationToken = default)
        {
            var foodId = await _kitchenModule.ExecuteCommandAsync(new CreateFoodCommand(
                data.Name,
                data.Description,
                data.Price,
                data.Image,
                data.FoodCategoryId,
                data.ProjectId), cancellationToken);

            return Ok(foodId);
        }

        /// <summary>
        /// Обновление блюда
        /// </summary>
        [HttpPut("{foodId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateFood(
            [FromBody] FoodRequestDto data,
            string foodId,
            CancellationToken cancellationToken = default)
        {
            await _kitchenModule.ExecuteCommandAsync(new UpdateFoodCommand(
                Guid.Parse(foodId),
                data.Name,
                data.Description,
                data.Price,
                data.Image,
                data.FoodCategoryId,
                data.ProjectId), cancellationToken);

            return Ok();
        }

        /// <summary>
        /// Удалить блюдо и все истории цен
        /// </summary>
        [HttpDelete("{foodId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteFood(string foodId, CancellationToken cancellationToken = default)
        {
            await _kitchenModule.ExecuteCommandAsync(new DeleteFoodCommand(foodId), cancellationToken);
            return Ok();
        }
    }
}
