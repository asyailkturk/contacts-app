using Report.API.Entities;

namespace Report.API.Helper
{
    public class ReportMapper
    {
        public static List<ReportData> MapFromRangeData(IList<IList<object>> values)
        {
            List<ReportData> reportDatas = new();
            values.RemoveAt(0);
            foreach (IList<object> value in values)
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
            List<object> objectList = new() { reportData.Location, reportData.ContactCount, reportData.PhoneNumberCount };
            List<IList<object>> rangeData = new() { objectList };
            return rangeData;
        }

        public static IList<IList<object>> MapToRangeData(List<ReportData> reportData)
        {
            List<object> objectList = new() { "Location", "Contact Count", "PhoneNumber Count" };
            List<IList<object>> rangeData = new() { objectList };
            foreach (ReportData data in reportData)
            {
                rangeData.Add(new List<object>() { data.Location, data.ContactCount, data.PhoneNumberCount });
            }
            return rangeData;
        }
    }
}
