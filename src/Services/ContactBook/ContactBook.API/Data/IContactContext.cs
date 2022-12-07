using ContactBook.API.Entities;
using MongoDB.Driver;

namespace ContactBook.API.Data
{
    public interface IContactContext
    {
        IMongoCollection<Contact> Contacts { get; }
    }
}
