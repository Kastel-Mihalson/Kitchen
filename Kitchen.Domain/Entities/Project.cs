namespace Kitchen.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

        public Project()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}
