
using MassTransit;
using Report.API.EventBusEvent;
using Report.API.Service.Interfaces;

namespace Report.API.EventBusConsumer
{
    public class ReportCreateConsumer : IConsumer<ReportCreateEvent>
    {
        private readonly ILogger<ReportCreateConsumer> _logger;
        private readonly IReportService _reportService;

        public ReportCreateConsumer(IReportService reportService, ILogger<ReportCreateConsumer> logger)
        {
            _reportService = reportService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ReportCreateEvent> context)
        {
            await _reportService.CreateReport(context: context.Message);
            _logger.LogInformation("Event consumed.");
        }
    }
}
