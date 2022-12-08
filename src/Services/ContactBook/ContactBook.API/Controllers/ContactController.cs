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


        public ContactController( IContactRepository repository) =>
           _repository = repository;
        


        [HttpGet]
        public async Task<List<Contact>> Get() =>
            await _repository.GetAsync();

        [HttpGet("{id}", Name = "GetContact")]
        public async Task<ActionResult<Contact>> Get(string id)
        {
            var contact = await _repository.GetAsync(id);

            if (contact is null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            await _repository.CreateAsync(contact);

            return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _repository.GetAsync(id);

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
          var result = await _repository.AddContactInfoAsync(id, contactInfo);

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
