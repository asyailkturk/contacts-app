using Report.API.Entities;

namespace Report.API.Repository
{
    public interface IReportRepository
    {
        Task<List<ReportResult>> GetAsync();
        Task<ReportResult?> GetAsync(string id);
        Task<ReportResult> CreateAsync(ReportResult reportResult);
        Task<bool> UpdateAsync(ReportResult reportResult);
    }
}
