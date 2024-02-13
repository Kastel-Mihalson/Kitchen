namespace Kitchen.Dto.Foods
{
    public class FoodRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public Guid FoodCategoryId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
