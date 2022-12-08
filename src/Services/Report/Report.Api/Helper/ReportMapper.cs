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
                    ContactCount = Convert.ToInt32(value[1]),
                    PhoneNumberCount = Convert.ToInt32(value[2])
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
            var list= reportData.Cast<object>().ToList();
            var rangeData = new List<IList<object>> { list };
            return rangeData;
        }
    }
}
