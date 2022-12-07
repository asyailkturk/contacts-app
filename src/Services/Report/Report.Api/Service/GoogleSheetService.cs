using Google.Apis.Sheets.v4;
using Report.Api.Entities;
using Report.API.Helper;

namespace Report.API.Service
{
    public class GoogleSheetService : IGoogleSheetService
    {
        const string SPREADSHEET_ID = "11qqVJ0rZXONJP-QCBxs5S_u5DuxIG8dctRCAPDPsJJE";
        const string SHEET_NAME = "Reports";
        SpreadsheetsResource.ValuesResource _googleSheetValues;

        public GoogleSheetService(GoogleSheetsHelper googleSheetsHelper)
        {
            _googleSheetValues = googleSheetsHelper.Service.Spreadsheets.Values;
        }
        public async Task<List<ReportData>> Get()
        {
            var range = $"{SHEET_NAME}!A:C";
            var request = _googleSheetValues.Get(SPREADSHEET_ID, range);
            var response = request.Execute();
            var values = response.Values;
            return ReportMapper.MapFromRangeData(values);
        }
    }
}
