

using Report.API.Models;
using Report.API.Service.Interfaces;

namespace Report.API.Service
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;
        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://host.docker.internal:8000/");
        }
        public async Task<List<GetContactsResponseModel?>> GetData()
        {
            return await _httpClient.GetFromJsonAsync<List<GetContactsResponseModel?>>("api/Contact");
            
        }
    }
}
