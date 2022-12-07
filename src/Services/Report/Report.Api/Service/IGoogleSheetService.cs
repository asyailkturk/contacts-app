using Report.Api.Entities;

namespace Report.API.Service
{
    public interface IGoogleSheetService
    {
        Task<List<ReportData>> Get();


    }
}
