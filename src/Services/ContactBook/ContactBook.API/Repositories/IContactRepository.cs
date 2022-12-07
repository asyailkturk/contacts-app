using ContactBook.API.Entities;

namespace ContactBook.API.Repositories
{
    public interface IContactRepository
    {

        Task CreateAsync(Contact contact);


        Task DeleteAsync(string id);


        Task<bool> AddContactInfoAsync(string id, CommunicationInfo contactInfo);


        Task DeleteCommunicationInfoAsync(string id);

        Task<List<Contact>> GetAsync();


        Task<Contact?> GetAsync(string id);
    }
}
