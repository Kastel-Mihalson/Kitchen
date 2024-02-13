namespace Kitchen.Domain.Entities
{
    public class Food
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId {get;set;}
        public virtual FoodCategory Category { get; set; }
        public Guid ProjectId { get; set; }
        public string? Image { get; set; }

        public Food()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}
