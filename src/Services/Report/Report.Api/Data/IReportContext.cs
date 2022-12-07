using MongoDB.Driver;
using Report.API.Entities;

namespace Report.Api.Data
{
    public interface IReportContext
    {
        IMongoCollection<ReportResult> ReportResults { get; }
    }
}
