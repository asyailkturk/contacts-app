
using Report.API.Entities;
using Report.API.EventBusEvent;

namespace Report.API.Service.Interfaces
{
    public interface IReportService
    {
        Task CreateReportRequest();
        Task CreateReport(ReportCreateEvent context);
        Task<List<ReportResult>> GetAsync();
        Task<ReportResult?> GetAsync(string id);
    }
}
