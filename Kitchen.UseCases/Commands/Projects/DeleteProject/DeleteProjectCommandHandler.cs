using Kitchen.UseCases.Configurations.Commands;
using Kitchen.UseCases.Interfaces;

namespace Kitchen.UseCases.Commands.Projects.DeleteProject
{
    public record DeleteProjectCommandHandler : ICommandHandler<DeleteProjectCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.Projects.GetProjectById(Guid.Parse(request.Id));

            if (project is null)
            {
                throw new Exception($"Project with id: {request.Id} not found");
            }

            _unitOfWork.Projects.Delete(project);

            await _unitOfWork.SaveAsync();
        }
    }
}
