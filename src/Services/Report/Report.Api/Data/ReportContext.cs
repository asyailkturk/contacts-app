using MongoDB.Driver;
using Report.API.Entities;

namespace Report.API.Data
{
    public class ReportContext : IReportContext
    {
        public ReportContext(IConfiguration configuration)
        {
            MongoClient client = new(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            IMongoDatabase database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            ReportResults = database.GetCollection<ReportResult>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        }
        public IMongoCollection<ReportResult> ReportResults { get; }
    }
}
