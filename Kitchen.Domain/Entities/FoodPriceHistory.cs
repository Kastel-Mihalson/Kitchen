namespace Kitchen.Domain.Entities
{
    public class FoodPriceHistory
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid FoodId { get; set; }
        public decimal Price { get; set; }

        public FoodPriceHistory()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}
