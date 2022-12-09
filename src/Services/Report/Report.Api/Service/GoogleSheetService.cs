using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Microsoft.AspNetCore.Mvc;
using Report.API.Entities;
using Report.API.Helper;
using Report.API.Service.Interfaces;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource.AppendRequest;

namespace Report.API.Service
{
    public class GoogleSheetService : IGoogleSheetService
    {
        const string SPREADSHEET_ID = "11qqVJ0rZXONJP-QCBxs5S_u5DuxIG8dctRCAPDPsJJE";
      
        SpreadsheetsResource _googleSheetService;
        

        public GoogleSheetService(GoogleSheetsHelper googleSheetsHelper)
        {
            _googleSheetService = googleSheetsHelper.Service.Spreadsheets;
        }
        private async Task<List<ReportData>> GetData(string spreadSheetId)
        {
            var range = "A:C";
            var request = _googleSheetService.Values.Get(spreadSheetId, range);
            
            var response =  await request.ExecuteAsync();
            var values = response.Values;
            return ReportMapper.MapFromRangeData(values);
        }
        public async Task<string> AddDatas(List<ReportData> reports)
        {
            var newSheet = await CreateNewSheet();
            var title = newSheet.Replies.FirstOrDefault().AddSheet.Properties.Title;
            var range = $"{title}!A:C";
            var valueRange = new List<ValueRange>
            {
                new ValueRange()
                {
                     Values = ReportMapper.MapToRangeData(reports),
                     Range = range,
                     MajorDimension = "ROWS"
                }
               
            };
            var body = new BatchUpdateValuesRequest();
            body.ValueInputOption = "USER_ENTERED";
            body.Data = valueRange;

            await _googleSheetService.Values.BatchUpdate(body , SPREADSHEET_ID).ExecuteAsync();

            return title;
        }
        private async Task<Spreadsheet> CreateNewSpreadSheet()
        {

            var sheetBody = new Spreadsheet();
            sheetBody.Properties.Title = $"{DateTime.Now.ToString()}+ Report";
            var request = _googleSheetService.Create(sheetBody);
          
            return await request.ExecuteAsync();
        }
        private async Task<BatchUpdateSpreadsheetResponse> CreateNewSheet()
        {

            var body = new BatchUpdateSpreadsheetRequest();

            var bodyItem = new Request();
            bodyItem.AddSheet = new AddSheetRequest
            {
                Properties = new SheetProperties
                { Title = $"{DateTime.UtcNow.AddHours(3).ToString()}+ Report" }
            };
            body.Requests = new Request[] { bodyItem };
            
            var request = _googleSheetService.BatchUpdate(body, SPREADSHEET_ID);

            return await request.ExecuteAsync();
        }



    }
}
