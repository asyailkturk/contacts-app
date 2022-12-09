
using Report.API.Entities;
using Report.API.Models;

namespace Report.API.Service.Interfaces
{
    public interface IReportService
    {
        Task CreateReport(ReportResult report = null, List<GetContactsResponseModel> contacts = null);
        Task CreateReportRequest();
        Task<List<ReportResult>> GetAsync();
        Task<ReportResult?> GetAsync(string id);
    }
}
