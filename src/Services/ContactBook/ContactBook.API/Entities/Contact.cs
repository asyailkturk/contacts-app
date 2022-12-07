﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ContactBook.API.Entities
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<CommunicationInfo> CommunicationInfo { get; set; }

    }
}