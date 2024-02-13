using Kitchen.Domain.Entities;
using Kitchen.UseCases.Configurations.Commands;
using Kitchen.UseCases.Interfaces;

namespace Kitchen.UseCases.Commands.Foods.CreateFood
{
    public class CreateFoodCommandHandler : ICommandHandler<CreateFoodCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateFoodCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            var foodId = Guid.NewGuid();

            _unitOfWork.Foods.Create(new Food
            {
                Id = foodId,
                Name = request.Name,
                Description = request.Description,
                Image = request.Image,
                Price = request.Price,
                CategoryId = request.FoodCategoryId,
                ProjectId = request.ProjectId
            });

            _unitOfWork.FoodPriceHistories.Create(new FoodPriceHistory
            {
                Id = Guid.NewGuid(),
                FoodId = foodId,
                Price = request.Price
            });

            await _unitOfWork.SaveAsync();

            return foodId;
        }
    }
}
