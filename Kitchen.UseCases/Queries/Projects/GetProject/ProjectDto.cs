namespace Kitchen.UseCases.Queries.Projects.GetProject
{
    public record ProjectDto(
        Guid Id,
        DateTime CreationDate,
        string Name,
        string Description,
        string? Image);
}
