using ContactBook.API.Entities;
using MongoDB.Driver;

namespace ContactBook.API.Data
{
    public class ContactContext : IContactContext
    {
        public ContactContext(IConfiguration configuration)
        {
            MongoClient client = new(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            IMongoDatabase database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Contacts = database.GetCollection<Contact>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            ContactContextSeed.SeedData(Contacts);
        }
        public IMongoCollection<Contact> Contacts { get; }
    }
}
