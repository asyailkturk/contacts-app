using ContactBook.API.Entities;
using ContactBook.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ContactBook.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repository;


        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Contact>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Contact>>> Get()
        {
            var contacts = await _repository.GetAsync();
            return Ok(contacts);
        }



        [HttpGet("{id}", Name = "GetContact")]
        public async Task<ActionResult<Contact>> Get(string id)
        {
            Contact? contact = await _repository.GetAsync(id);

            return contact is null ? (ActionResult<Contact>)NotFound() : (ActionResult<Contact>)Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _repository.CreateAsync(contact);

            return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            Contact? book = await _repository.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut]
        [Route("{id}/[action]")]
        public async Task<ActionResult> AddContactInfo(string id, [FromBody] CommunicationInfo contactInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = await _repository.AddContactInfoAsync(id, contactInfo);

            return result ? NoContent() : BadRequest("Contact has already contain this information.");

        }

        [HttpPut]
        [Route("{id}/[action]")]
        public async Task<ActionResult> DeleteContactInfo(string id)
        {
            await _repository.DeleteCommunicationInfoAsync(id);

            return NoContent();
        }

    }
}
