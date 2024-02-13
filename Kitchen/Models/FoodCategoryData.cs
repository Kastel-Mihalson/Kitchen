using System.ComponentModel.DataAnnotations;

namespace Kitchen.Models
{
    public class FoodCategoryData
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectId { get; set; }
    }
}
