using Report.API.Entities;

namespace Report.API.Service.Interfaces
{
    public interface IGoogleSheetService
    {
        Task<string> AddDatas(List<ReportData> reports);


    }
}
