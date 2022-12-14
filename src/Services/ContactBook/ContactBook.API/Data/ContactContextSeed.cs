using ContactBook.API.Entities;
using MongoDB.Driver;

namespace ContactBook.API.Data
{
    public class ContactContextSeed
    {
        public static void SeedData(IMongoCollection<Contact> contactCollection)
        {
            bool exist = contactCollection.Find(p => true).Any();
            if (!exist)
            {
                contactCollection.InsertMany(GetPreconfiguredContacts());
            }
        }

        private static IEnumerable<Contact> GetPreconfiguredContacts()
        {
            return new List<Contact>()
            {
                new Contact()
                {
                    FirstName = "Asya",
                    LastName = "İlktürk",
                    Company ="CompanyA",
                    CommunicationInfo = new List<CommunicationInfo>
                    {
                        new CommunicationInfo
                        {
                            Detail = "Ankara",
                            InfoType = CommunationInfoType.Location
                        },
                         new CommunicationInfo
                        {
                            Detail = "05555555555",
                            InfoType = CommunationInfoType.PhoneNumber
                        },
                           new CommunicationInfo
                        {
                            Detail = "asya.ilkturk@gmail.com",
                            InfoType = CommunationInfoType.Email
                        },
                    }
                },
                new Contact()
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Company ="CompanyB",
                    CommunicationInfo = new List<CommunicationInfo>
                    {
                        new CommunicationInfo
                        {
                            Detail = "Ankara",
                            InfoType = CommunationInfoType.Location
                        },
                         new CommunicationInfo
                        {
                            Detail = "05555555555",
                            InfoType = CommunationInfoType.PhoneNumber
                        },
                           new CommunicationInfo
                        {
                            Detail = "janedoe@gmail.com",
                            InfoType = CommunationInfoType.Email
                        },
                    }
                },
                new Contact()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Company ="CompanyC",
                    CommunicationInfo = new List<CommunicationInfo>
                    {
                        new CommunicationInfo
                        {
                            Detail = "Istanbul",
                            InfoType = CommunationInfoType.Location
                        },
                         new CommunicationInfo
                        {
                            Detail = "05555555555",
                            InfoType = CommunationInfoType.PhoneNumber
                        },
                           new CommunicationInfo
                        {
                            Detail = "johndoe@gmail.com",
                            InfoType = CommunationInfoType.Email
                        },
                    }
                }

            };
        }
    }
}
