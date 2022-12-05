using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ContactBook.API.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<CommunicationInfo> CommunicationInfo { get; set; }
    }
}
