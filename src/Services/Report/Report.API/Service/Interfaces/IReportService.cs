
using Report.API.Entities;
using Report.API.EventBusEvent;

namespace Report.API.Service.Interfaces
{
    public interface IReportService
    {
        Task CreateReportRequest();
        Task<List<ReportResult>> GetAsync();
        Task<ReportResult?> GetAsync(string id);
    }
}
