
namespace ContactBook.API.Entities
{
    public class CommunicationInfo
    {
        public CommunationInfoType InfoType { get; set; }

        public string Detail { get; set; }
    }

    public enum CommunationInfoType
    {
        PhoneNumber,
        Email,
        Location
    }

}
