
using Report.API.Entities;
using Report.API.EventBusEvent;
using Report.API.Models;

namespace Report.API.Service.Interfaces
{
    public interface IReportService
    {
        Task CreateReport(ReportCreateEvent? context = null);
        Task CreateReportRequest();
        Task<List<ReportResult>> GetAsync();
        Task<ReportResult?> GetAsync(string id);
    }
}
