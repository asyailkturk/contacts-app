
using Microsoft.AspNetCore.Mvc;
using Report.API.Repository;
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
        public async Task<List<ReportResult>> Get() =>
            await _reportService.GetAsync();

        [HttpGet("{id}", Name = "GetReport")]
        public async Task<ActionResult<ReportResult>> Get(string id)
        {
            var contact = await _reportService.GetAsync(id);

            if (contact is null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateReportRequest()
        {
           await _reportService.CreateReport();

            return Ok();
        }
    }
}
