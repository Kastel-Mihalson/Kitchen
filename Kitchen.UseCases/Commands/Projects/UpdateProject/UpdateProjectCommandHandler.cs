using Kitchen.UseCases.Configurations.Commands;
using Kitchen.UseCases.Interfaces;

namespace Kitchen.UseCases.Commands.Projects.UpdateProject
{
    public record UpdateProjectCommandHandler : ICommandHandler<UpdateProjectCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.Projects.GetProjectById(Guid.Parse(request.Id));

            if (project is null)
            {
                throw new Exception($"Project with id {request.Id} not found!");
            }

            if (project.Name != request.Name)
            {
                project.Name = request.Name;
            }
            if (project.Description != request.Description)
            {
                project.Description = request.Description;
            }
            if (project.Image != request.Image)
            {
                project.Image = request.Image;
            }

            _unitOfWork.Projects.Update(project);

            await _unitOfWork.SaveAsync();
        }
    }
}
