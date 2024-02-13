namespace Kitchen.UseCases.Queries.Users.GetUser
{
    public record UserDto(
        Guid Id,
        string Name,
        string Email,
        DateTime CreationDate);
}
