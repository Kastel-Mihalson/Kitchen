using System.Runtime.Serialization;

namespace Kitchen.Dto.FoodPrices
{
    [DataContract]
    public class FoodPricesResponseDto
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "creationDate")]
        public string CreationDate { get; set; }

        [DataMember(Name = "price")]
        public decimal Price { get; set; }
    }
}
