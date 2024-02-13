using Kitchen.Dto.Projects;
using Kitchen.Mappers;
using Kitchen.UseCases.Commands.Projects.CreateProject;
using Kitchen.UseCases.Commands.Projects.DeleteProject;
using Kitchen.UseCases.Commands.Projects.UpdateProject;
using Kitchen.UseCases.Configurations;
using Kitchen.UseCases.Queries.Projects.GetProject;
using Kitchen.UseCases.Queries.Projects.GetProjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IKitchenModule _kitchenModule;

        public ProjectsController(IKitchenModule kitchenModule)
        {
            _kitchenModule = kitchenModule;
        }

        /// <summary>
        /// Получение списка проектов
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<ProjectResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProjects(CancellationToken cancellationToken = default)
        {
            var projects = await _kitchenModule.ExecuteQueryAsync(new GetProjectsQuery(), cancellationToken);
            return Ok(projects.Map());
        }

        /// <summary>
        /// Получение данных проекта
        /// </summary>
        [HttpGet("{projectId}")]
        [ProducesResponseType(typeof(ProjectResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProject(
            string projectId, 
            CancellationToken cancellationToken = default)
        {
            var project = await _kitchenModule.ExecuteQueryAsync(new GetProjectQuery(projectId), cancellationToken);

            if (project is null)
            {
                return NotFound();
            }

            return Ok(project.Map());
        }

        /// <summary>
        /// Добавление нового проекта
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateProject(
            [FromBody] ProjectRequestDto data,
            CancellationToken cancellationToken = default)
        {
            var projectId = await _kitchenModule.ExecuteCommandAsync(
                new CreateProjectCommand(data.Name, data.Description, data.Image), cancellationToken);

            return Ok(projectId);
        }

        /// <summary>
        /// Обновление проекта
        /// </summary>
        [HttpPut("{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProject(
            [FromBody] ProjectRequestDto data,
            string projectId,
            CancellationToken cancellationToken = default)
        {
            await _kitchenModule.ExecuteCommandAsync(new UpdateProjectCommand(
                projectId,
                data.Name,
                data.Description,
                data.Image), cancellationToken);

            return Ok();
        }

        /// <summary>
        /// Удаление проекта
        /// </summary>
        [HttpDelete("{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteProject(
            string projectId, 
            CancellationToken cancellationToken = default)
        {
            await _kitchenModule.ExecuteCommandAsync(new DeleteProjectCommand(projectId), cancellationToken);
            return Ok();
        }
    }
}
