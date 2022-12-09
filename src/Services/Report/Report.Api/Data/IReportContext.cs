using MongoDB.Driver;
using Report.API.Entities;

namespace Report.API.Data
{
    public interface IReportContext
    {
        IMongoCollection<ReportResult> ReportResults { get; }
    }
}
