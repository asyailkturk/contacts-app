
using Microsoft.AspNetCore.Mvc;
using Report.API.Entities;
using Report.API.Service.Interfaces;

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
        public async Task<List<ReportResult>> Get()
        {
            return await _reportService.GetAsync();
        }

        [HttpGet("{id}", Name = "GetReport")]
        public async Task<ActionResult<ReportResult>> Get(string id)
        {
            ReportResult? contact = await _reportService.GetAsync(id);

            return contact is null ? (ActionResult<ReportResult>)NotFound() : (ActionResult<ReportResult>)Ok(contact);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateReportRequest()
        {
            await _reportService.CreateReportRequest();

            return Ok();
        }
    }
}
