
using Microsoft.AspNetCore.Mvc;
using Report.API.Entities;
using Report.API.Service.Interfaces;
using System.Net;

namespace Report.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReportResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ReportResult>>> Get()
        {
            var reports = await _reportService.GetAsync();
            return Ok(reports);
        }

        [HttpGet("{id}", Name = "GetReport")]
        public async Task<ActionResult<ReportResult>> Get(string id)
        {
            ReportResult? report = await _reportService.GetAsync(id);

            return report is null ? (ActionResult<ReportResult>)NotFound() : (ActionResult<ReportResult>)Ok(report);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> CreateReportRequest()
        {
            await _reportService.CreateReportRequest();

            return Ok();
        }
    }
}
