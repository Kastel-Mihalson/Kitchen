using Kitchen.Dto.Projects;
using Kitchen.UseCases.Queries.Projects.GetProject;

namespace Kitchen.Mappers
{
    public static class ProjectMapper
    {
        public static ProjectResponseDto Map(this ProjectDto projectDto)
        {
            return new ProjectResponseDto
            {
                Id = projectDto.Id.ToString(),
                Name = projectDto.Name,
                Description = projectDto.Description,
                Image = projectDto.Image,
                CreationDate = projectDto.CreationDate
            };
        }

        public static IReadOnlyList<ProjectResponseDto> Map(this IReadOnlyList<ProjectDto> projectDtos)
        {
            return projectDtos.Select(Map).ToList();
        }
    }
}
