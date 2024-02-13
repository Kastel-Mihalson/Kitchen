using Kitchen.Domain.Entities;
using Kitchen.UseCases.Configurations.Commands;
using Kitchen.UseCases.Interfaces;

namespace Kitchen.UseCases.Commands.Foods.UpdateFood
{
    public class UpdateFoodCommandHandler : ICommandHandler<UpdateFoodCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFoodCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
        {
            var food = await _unitOfWork.Foods.GetFoodById(request.Id);

            if (food is null)
            {
                throw new Exception($"Food with id: {request.Id} not found!");
            }

            if (food.Name != request.Name)
            {
                food.Name = request.Name;
            }
            if (food.Description != request.Description)
            {
                food.Description = request.Description;
            }
            if (food.Price != request.Price)
            {
                food.Price = request.Price;

                _unitOfWork.FoodPriceHistories.Create(new FoodPriceHistory
                {
                    Id = Guid.NewGuid(),
                    FoodId = food.Id,
                    Price = request.Price
                });
            }
            if (food.Image != request.Image)
            {
                food.Image = request.Image;
            }
            if (food.CategoryId != request.FoodCategoryId)
            {
                food.CategoryId = request.FoodCategoryId;
            }
            if (food.ProjectId != request.ProjectId)
            {
                food.ProjectId = request.ProjectId;
            }

            _unitOfWork.Foods.Update(food);

            await _unitOfWork.SaveAsync();
        }
    }
}
