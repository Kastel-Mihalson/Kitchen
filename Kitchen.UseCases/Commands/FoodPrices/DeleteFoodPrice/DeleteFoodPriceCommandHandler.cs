using Kitchen.UseCases.Configurations.Commands;
using Kitchen.UseCases.Interfaces;

namespace Kitchen.UseCases.Commands.FoodPrices.DeleteFoodPrice
{
    public class DeleteFoodPriceCommandHandler : ICommandHandler<DeleteFoodPriceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFoodPriceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteFoodPriceCommand request, CancellationToken cancellationToken)
        {
            var foodPrice = await _unitOfWork.FoodPriceHistories.GetFoodPriceHistoryById(Guid.Parse(request.Id));

            if (foodPrice is null)
            {
                throw new Exception($"Food price history with id {request.Id} not found!");
            }

            _unitOfWork.FoodPriceHistories.Delete(foodPrice);

            await _unitOfWork.SaveAsync();
        }
    }
}
