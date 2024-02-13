using System.Runtime.Serialization;

namespace Kitchen.Dto.FoodCategories
{
    [DataContract]
    public class FoodCategoryResponseDto
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "projectId")]
        public string ProjectId { get; set; }
    }
}
