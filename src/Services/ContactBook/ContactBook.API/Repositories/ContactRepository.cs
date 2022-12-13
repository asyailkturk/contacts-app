using ContactBook.API.Data;
using ContactBook.API.Entities;
using MongoDB.Driver;

namespace ContactBook.API.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IContactContext _context;


        public ContactRepository(IContactContext context)
        {

            _context = context;
        }

        public async Task<List<Contact>> GetAsync()
        {
            return await _context.Contacts.Find(_ => true).ToListAsync();
        }

        public async Task<Contact?> GetAsync(string id)
        {
            return await _context.Contacts.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Contact contact)
        {
            await _context.Contacts.InsertOneAsync(contact);
        }

        public async Task DeleteAsync(string id)
        {
            await _context.Contacts.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<bool> AddContactInfoAsync(string id, CommunicationInfo contactInfo)
        {
            Contact contact = _context.Contacts.Find(p => p.Id == id).Single();

            if (contactInfo != null && contact != null && !contact.CommunicationInfo.Where(x => x.InfoType == contactInfo.InfoType).Any())
            {
                contact.CommunicationInfo.Add(contactInfo);
                await _context.Contacts.ReplaceOneAsync(p => p.Id == id, contact);
                return true;

            }
            return false;

        }

        public async Task DeleteCommunicationInfoAsync(string id)
        {
            Contact contact = _context.Contacts.Find(p => p.Id == id).Single();

            if (contact != null)
            {
                contact.CommunicationInfo.Clear();

                await _context.Contacts.ReplaceOneAsync(p => p.Id == id, contact);

            }
        }


    }
}
