using Report.Api.Entities;

namespace Report.API.Helper
{
    public class ReportMapper
    {
        public static List<ReportData> MapFromRangeData(IList<IList<object>> values)
        {
            var reportDatas = new List<ReportData>();
            foreach (var value in values)
            {
                ReportData reportData = new()
                {
                    Location = value[0].ToString(),
                    ContactCount = (int)value[1],
                    PhoneNumberCount = (int)value[2]
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
    }
}
