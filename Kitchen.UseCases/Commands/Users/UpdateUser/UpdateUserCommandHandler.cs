using Kitchen.UseCases.Configurations.Commands;
using Kitchen.UseCases.Interfaces;
using Kitchen.Common.Utils;

namespace Kitchen.UseCases.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetUserById(request.Id);

            if (user is null)
            {
                throw new Exception($"User with id {request.Id} not found!");
            }

            if (user.Name != request.Name)
            {
                user.Name = request.Name;
            }
            if (user.Email != request.Email)
            {
                user.Email = request.Email;
            }

            if (!PasswordHashingManager.VerifyPassword(request.Password, user.Password)) {
                user.Password = PasswordHashingManager.HashPassword(request.Password);
            }

            _unitOfWork.Users.Update(user);

            await _unitOfWork.SaveAsync();
        }
    }
}
