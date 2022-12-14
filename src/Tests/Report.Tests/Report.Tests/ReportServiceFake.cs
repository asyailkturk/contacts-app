
using Report.API.Entities;
using Report.API.EventBusEvent;
using Report.API.Service.Interfaces;

namespace Report.Tests
{
    public class ReportServiceFake : IReportService
    {
        private readonly List<ReportResult> _reports;
        public ReportServiceFake()
        {
            _reports = new List<ReportResult>()
            { new ReportResult()
            {
                Id= new string("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                CreatedDate= DateTime.Now.AddDays(-1),
                QueueId="1",
                ReportUrl="url",
                Status= Status.Done
            },
            new ReportResult()
            {
                Id= new string("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                CreatedDate= DateTime.Now.AddHours(-2),
                QueueId="2",
                ReportUrl="url",
                Status= Status.Done
            },
             new ReportResult()
            {
                Id= new string("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                CreatedDate= DateTime.Now.AddMinutes(-10),
                QueueId="3",
                ReportUrl="url",
                Status= Status.Done
            },
            };
        }

        public Task CreateReport(ReportCreateEvent context)
        {
            context.Report.ReportUrl = "URL";
            context.Report.Title = "title";
            context.Report.Status = Status.Done;
            _reports.Add(context.Report);
            return Task.FromResult(context.Report);
        }

        public Task CreateReportRequest()
        {
            ReportResult reportResult = new()
            {
                CreatedDate = DateTime.Now,
                Status = Status.Prepraring,
                Id = Guid.NewGuid().ToString()
            };
            _reports.Add(reportResult);
            return Task.FromResult(reportResult);
        }

        public Task<List<ReportResult>> GetAsync()
        {
            return Task.FromResult(_reports);
        }


        public Task<ReportResult?> GetAsync(string id)
        {
            return Task.FromResult(_reports.Where(a => a.Id == id).FirstOrDefault());
        }
    }
}