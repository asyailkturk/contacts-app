using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Report.API.Entities;
using Report.API.Helper;
using Report.API.Service.Interfaces;

namespace Report.API.Service
{
    public class GoogleSheetService : IGoogleSheetService
    {
        private const string SPREADSHEET_ID = "11qqVJ0rZXONJP-QCBxs5S_u5DuxIG8dctRCAPDPsJJE";
        private readonly SpreadsheetsResource _googleSheetService;


        public GoogleSheetService(GoogleSheetsHelper googleSheetsHelper)
        {
            _googleSheetService = googleSheetsHelper.Service.Spreadsheets;
        }
      
        public async Task<string> AddDatas(List<ReportData> reports)
        {
            BatchUpdateSpreadsheetResponse newSheet = await CreateNewSheet();
            string title = newSheet?.Replies?.FirstOrDefault().AddSheet.Properties.Title;
            string range = $"{title}!A:C";
            List<ValueRange> valueRange = new()
            {
                new ValueRange()
                {
                     Values = ReportMapper.MapToRangeData(reports),
                     Range = range,
                     MajorDimension = "ROWS"
                }

            };
            BatchUpdateValuesRequest body = new()
            {
                ValueInputOption = "USER_ENTERED",
                Data = valueRange
            };

            await _googleSheetService.Values.BatchUpdate(body , SPREADSHEET_ID).ExecuteAsync();

            return title;
        }
       
        private async Task<BatchUpdateSpreadsheetResponse> CreateNewSheet()
        {

            BatchUpdateSpreadsheetRequest body = new();

            Request bodyItem = new()
            {
                AddSheet = new AddSheetRequest
                {
                    Properties = new SheetProperties
                    { Title = $"{DateTime.UtcNow.AddHours(3)}+ Report" }
                }
            };
            body.Requests = new Request[] { bodyItem };

            var request = _googleSheetService.BatchUpdate(body, SPREADSHEET_ID);

            return await request.ExecuteAsync();
        }



    }
}
