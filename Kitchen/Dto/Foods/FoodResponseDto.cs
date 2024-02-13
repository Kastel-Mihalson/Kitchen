using System.Runtime.Serialization;

namespace Kitchen.Dto.Foods
{

    [DataContract]
    public class FoodResponseDto
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [DataMember(Name = "creationDate")]
        public DateTime CreationDate { get; set; }

        [DataMember(Name = "image")]
        public string? Image { get; set; }

        [DataMember(Name = "foodCategoryId")]
        public string FoodCategoryId { get; set; }

        [DataMember(Name = "projectId")]
        public string ProjectId { get; set; }
    }
}
