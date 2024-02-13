using System.Runtime.Serialization;

namespace Kitchen.Dto.Users
{
    [DataContract]
    public class UserResponseDto
    {

        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "creationDate")]
        public DateTime CreationDate { get; set; }
    }
}
