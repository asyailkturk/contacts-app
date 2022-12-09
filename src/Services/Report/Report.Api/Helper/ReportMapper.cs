using Google.Apis.Sheets.v4.Data;
using Report.API.Entities;

namespace Report.API.Helper
{
    public class ReportMapper
    {
        public static List<ReportData> MapFromRangeData(IList<IList<object>> values)
        {
            var reportDatas = new List<ReportData>();
            values.RemoveAt(0);
            foreach (var value in values)
            {
                ReportData reportData = new()
                {
                    Location = value[0].ToString(),
                    ContactCount = value[1].ToString(),
                    PhoneNumberCount = value[2].ToString()
                };
                reportDatas.Add(reportData);
            }
            return reportDatas;
        }
        public static IList<IList<object>> MapToRangeData(ReportData reportData)
        {
            var objectList = new List<object>() { reportData.Location, reportData.ContactCount,reportData.PhoneNumberCount };
            var rangeData = new List<IList<object>> { objectList };
            return rangeData;
        }

        public static IList<IList<object>> MapToRangeData(List<ReportData> reportData)
        {
            var objectList = new List<object>() {"Location", "Contact Count", "PhoneNumber Count" };
            var rangeData = new List<IList<object>> { objectList };
            foreach (var data in reportData)
            {
                rangeData.Add(new List<object>() { data.Location, data.ContactCount, data.PhoneNumberCount });
            }
            return rangeData;
        }
    }
}
