using Kitchen.Dto.FoodPrices;
using Kitchen.Mappers;
using Kitchen.UseCases.Commands.FoodPrices.DeleteFoodPrice;
using Kitchen.UseCases.Configurations;
using Kitchen.UseCases.Queries.FoodPrices.GetFoodPricesByFoodId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodPriceHistoriesController : ControllerBase
    {
        private readonly IKitchenModule _kitchenModule;

        public FoodPriceHistoriesController(IKitchenModule kitchenModule)
        {
            _kitchenModule = kitchenModule;
        }

        [HttpGet("{foodId}")]
        [ProducesResponseType(typeof(IReadOnlyList<FoodPricesResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFoodPricesById(string foodId, CancellationToken cancellationToken = default)
        {
            var foodPrices = await _kitchenModule.ExecuteQueryAsync(new GetFoodPricesByFoodIdQuery(foodId), cancellationToken);
            return Ok(foodPrices.Map());
        }

        [HttpDelete("{priceId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteFoodPrice(string priceId, CancellationToken cancellationToken = default)
        {
            await _kitchenModule.ExecuteCommandAsync(new DeleteFoodPriceCommand(priceId), cancellationToken);
            return Ok();
        }
    }
}
