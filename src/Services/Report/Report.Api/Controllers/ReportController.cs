
using Microsoft.AspNetCore.Mvc;
using Report.Api.Repository;
using Report.API.Entities;
using Report.API.Service;
using System.Net;

namespace Report.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _repository;
        private readonly IGoogleSheetService _service;


        public ReportController(IReportRepository repository, IGoogleSheetService service)
        {
            _repository = repository;
            _service = service;

        }
          


        [HttpGet]
        public async Task<List<ReportResult>> Get() =>
            await _repository.GetAsync();

        [HttpGet("{id}", Name = "GetReport")]
        public async Task<ActionResult<ReportResult>> Get(string id)
        {
            var contact = await _repository.GetAsync(id);

            if (contact is null)
            {
                return NotFound();
            }

            return Ok(contact);
        }



        [HttpPost]
        public async Task<IActionResult> test()
        {
            _service.Get();

            return Ok(_service.Get());
        }



    }
}
