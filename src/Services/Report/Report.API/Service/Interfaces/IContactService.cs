using Report.API.Models;

namespace Report.API.Service.Interfaces
{
    public interface IContactService
    {
        Task<List<GetContactsResponseModel?>> GetData();

    }
}
