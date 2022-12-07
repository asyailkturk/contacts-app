
//using Microsoft.AspNetCore.Mvc;
//using System.Net;

//namespace Report.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class ReportController : ControllerBase
//    {
//        //private readonly IContactRepository _repository;


//        //public ContactController( IContactRepository repository) =>
//        //   _repository = repository;
        


//        [HttpGet]
//        public async Task<List<Reports>> Get() =>
//            await _repository.GetAsync();

//        [HttpGet("{id}", Name = "GetReport")]
//        public async Task<ActionResult<Reports>> Get(string id)
//        {
//            var contact = await _repository.GetAsync(id);

//            if (contact is null)
//            {
//                return NotFound();
//            }

//            return Ok(contact);
//        }

//        [HttpPost]
//        public async Task<IActionResult> RequestLocationReport()
//        {
//             _repository.CreateAsync(contact);

//            return Ok();
//        }

      

//    }
//}
