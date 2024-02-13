using Kitchen.UseCases.Configurations.Commands;
using Kitchen.UseCases.Interfaces;

namespace Kitchen.UseCases.Commands.Users.DeleteUser
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetUserById(Guid.Parse(request.Id));

            if (user is null)
            {
                throw new Exception($"Use with id: {request.Id} not found!");
            }

            _unitOfWork.Users.Delete(user);

            await _unitOfWork.SaveAsync();
        }
    }
}
