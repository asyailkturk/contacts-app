using ContactBook.API.Controllers;
using ContactBook.API.Data;
using ContactBook.API.Entities;
using ContactBook.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace ContactBook.Tests
{
    public class ContactBookServiceFake : IContactRepository
    {
        private readonly List<Contact> _contacts;

        public ContactBookServiceFake()
        {
            _contacts = new List<Contact>()
            {
                new Contact() { Id = new string("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    FirstName = "Asya",LastName = "İlktürk", Company ="CompanyA",
                    CommunicationInfo = new List<CommunicationInfo> {
                    new CommunicationInfo { Detail = "Ankara", InfoType = CommunationInfoType.Location },
                    new CommunicationInfo { Detail = "05555555555", InfoType = CommunationInfoType.PhoneNumber},
                    new CommunicationInfo { Detail = "asya.ilkturk@gmail.com", InfoType = CommunationInfoType.Email},
                }},
                new Contact() { Id = new string("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    FirstName = "Jane",LastName = "Doe",Company ="CompanyB",
                    CommunicationInfo = new List<CommunicationInfo>{
                    new CommunicationInfo { Detail = "Ankara", InfoType = CommunationInfoType.Location},
                    new CommunicationInfo { Detail = "05555555555", InfoType = CommunationInfoType.PhoneNumber},
                    new CommunicationInfo { Detail = "janedoe@gmail.com", InfoType = CommunationInfoType.Email},
                }},
                new Contact() { Id = new string("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                    FirstName = "John", LastName = "Doe", Company ="CompanyC",
                    CommunicationInfo = new List<CommunicationInfo>{
                    new CommunicationInfo { Detail = "Istanbul", InfoType = CommunationInfoType.Location},
                    new CommunicationInfo { Detail = "05555555555", InfoType = CommunationInfoType.PhoneNumber},
                    
                }}
            };
        }
        public Task<List<Contact>> GetAsync()
        {;
            return Task.FromResult(_contacts);
        }
        public Task<Contact?> GetAsync(string id)
        {
            return Task.FromResult(_contacts.Where(a => a.Id == id).FirstOrDefault());
        }
        public Task CreateAsync(Contact newItem)
        {
            newItem.Id = Guid.NewGuid().ToString();
            _contacts.Add(newItem);
            return Task.CompletedTask;
        }
        public Task DeleteAsync(string id)
        {
            var existing = _contacts.First(a => a.Id == id);
            _contacts.Remove(existing);
            return Task.CompletedTask;
        }
        public Task<bool> AddContactInfoAsync(string id, CommunicationInfo contactInfo)
        {
            var existing = _contacts.First(a => a.Id == id);
            if (contactInfo != null && existing != null && !existing.CommunicationInfo.Where(x => x.InfoType == contactInfo.InfoType).Any())
            {
                _contacts.Find(x => x.Id == id).CommunicationInfo.Add(contactInfo);
                return Task.FromResult(true); ;
            }

            return Task.FromResult(false); ;
        }

        public Task DeleteCommunicationInfoAsync(string id)
        {
            var existing = _contacts.First(a => a.Id == id);

            if (existing != null)
            {
                _contacts.Find(x => x.Id == id).CommunicationInfo.Clear();
            }

            return Task.CompletedTask;
        }


    }
}