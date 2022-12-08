

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
            _httpClient.BaseAddress = new Uri("http://localhost:8000/");
        }
        public async Task<List<GetContactsResponseModel?>> GetData()
        {
            try
            {
               
                return await _httpClient.GetFromJsonAsync<List<GetContactsResponseModel?>>("api/Contact");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
