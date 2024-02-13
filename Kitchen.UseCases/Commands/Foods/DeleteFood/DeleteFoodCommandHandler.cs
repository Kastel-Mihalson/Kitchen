using Kitchen.UseCases.Configurations.Commands;
using Kitchen.UseCases.Interfaces;

namespace Kitchen.UseCases.Commands.Foods.DeleteFood
{
    public class DeleteFoodCommandHandler : ICommandHandler<DeleteFoodCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFoodCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
        {
            var food = await _unitOfWork.Foods.GetFoodById(Guid.Parse(request.Id));

            if (food is null)
            {
                throw new Exception($"Food with id {request.Id} not found!");
            }

            _unitOfWork.Foods.Delete(food);

            await _unitOfWork.SaveAsync();
        }
    }
}
