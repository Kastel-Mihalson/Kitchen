using Kitchen.Domain.Entities;
using Kitchen.UseCases.Configurations.Commands;
using Kitchen.UseCases.Interfaces;

namespace Kitchen.UseCases.Commands.Projects.CreateProject
{
    public class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var projectId = Guid.NewGuid();

            _unitOfWork.Projects.Create(new Project
            {
                Id = projectId,
                Name = request.Name,
                Description = request.Description,
                Image = request.Image
            });

            await _unitOfWork.SaveAsync();

            return projectId;
        }
    }
}
