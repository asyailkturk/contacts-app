using Google.Apis.Sheets.v4.Data;
using Report.API.Entities;
using Report.API.Helper;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource;

namespace Report.API.Service.Interfaces
{
    public interface IGoogleSheetService
    {
       Task<string> AddDatas(List<ReportData> reports);


    }
}
