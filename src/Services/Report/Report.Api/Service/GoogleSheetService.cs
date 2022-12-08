using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Microsoft.AspNetCore.Mvc;
using Report.Api.Entities;
using Report.API.Helper;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource;

namespace Report.API.Service
{
    public class GoogleSheetService : IGoogleSheetService
    {
        //const string SPREADSHEET_ID = "11qqVJ0rZXONJP-QCBxs5S_u5DuxIG8dctRCAPDPsJJE";
        //const string SHEET_NAME = "Reports";
        SpreadsheetsResource _googleSheetService;
        

        public GoogleSheetService(GoogleSheetsHelper googleSheetsHelper)
        {
            _googleSheetService = googleSheetsHelper.Service.Spreadsheets;
        }
        public List<ReportData> GetData(string spreadSheetId)
        {
            var range = "A:C";
            var request = _googleSheetService.Values.Get(spreadSheetId, range);
            
            var response = request.Execute();
            var values = response.Values;
            return ReportMapper.MapFromRangeData(values);
        }

        public void AddDatas(List<ReportData> reports, string spreadSheetId)
        {
            var range = "A:C";
            var valueRange = new ValueRange
            {
                Values = ReportMapper.MapToRangeData(reports)
            };

            var appendRequest = _googleSheetService.Values.Append(valueRange, spreadSheetId, range);
            appendRequest.ValueInputOption = AppendRequest.ValueInputOptionEnum.USERENTERED;
            appendRequest.Execute();
        }
        public Spreadsheet CreateNewSheet(List<ReportData> reportDatas)
        {
           
            var sheetBody = new Spreadsheet();
            sheetBody.Properties.Title= $"{DateTime.Now.ToString()}+ Report";
            var request = _googleSheetService.Create(sheetBody);
            
            return request.Execute();
        }



    }
}
