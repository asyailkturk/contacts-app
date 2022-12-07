using Report.API.Entities;

namespace Report.Api.Repository
{
    public interface IReportRepository
    {
        Task<List<ReportResult>> GetAsync();
        Task<ReportResult?> GetAsync(string id);
    }
}
