using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Report.API.Entities
{
    public class ReportResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public Status Status { get; set; }
        public string ReportUrl { get; set; }
        public string Title { get; set; }
        public string QueueId { get; set; }

    }

    public enum Status
    {
        Prepraring = 0,
        Done = 1,

    }

}
