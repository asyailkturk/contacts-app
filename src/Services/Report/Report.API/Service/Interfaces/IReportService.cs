
using Report.API.Entities;

namespace Report.API.Service.Interfaces
{
    public interface IReportService
    {
        Task CreateReport();
        Task<List<ReportResult>> GetAsync();
        Task<ReportResult?> GetAsync(string id);
    }
}
