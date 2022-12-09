using MongoDB.Driver;
using Report.API.Entities;

namespace Report.API.Data
{
    public class ReportContext : IReportContext
    {
        public ReportContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            ReportResults = database.GetCollection<ReportResult>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            //ContactContextSeed.SeedData(ReportResult);
        }
        public IMongoCollection<ReportResult> ReportResults { get; }
    }
}
