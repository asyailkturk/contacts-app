namespace Report.API.Models
{
    public class GetContactsResponseModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<CommunicationInfo> CommunicationInfo { get; set; }
    }
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
