using System.Runtime.Serialization;

namespace Kitchen.Dto.Projects
{

    [DataContract]
    public class ProjectResponseDto
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "creationDate")]
        public DateTime? CreationDate { get; set; }

        [DataMember(Name = "image")]
        public string? Image { get; set; }
    }
}
