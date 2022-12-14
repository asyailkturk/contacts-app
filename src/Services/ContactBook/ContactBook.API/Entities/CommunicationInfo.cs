
using System.ComponentModel.DataAnnotations;

namespace ContactBook.API.Entities
{
    public class CommunicationInfo
    {
        [Required]
        public CommunationInfoType InfoType { get; set; }

        [Required]

        public string Detail { get; set; }
    }

    public enum CommunationInfoType
    {
        PhoneNumber,
        Email,
        Location
    }

}
