using Microsoft.AspNetCore.Mvc;
using Ayra.Domain.Entities;
using Ayra.Application.Services;

namespace Ayra.Api.Controllers
{
    [ApiController]
    [Route("EmergencyContact")]
    public class EmergencyContactController : ControllerBase
    {
        private readonly EmergencyContactService _service;

        public EmergencyContactController(EmergencyContactService service)
        {
            _service = service;
        }

        // GET: api/emergencycontact
        [HttpGet]
        public IActionResult GetAll()
        {
            var contacts = _service.GetAll();
            return Ok(contacts);
        }

        // GET: api/emergencycontact/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _service.GetById(id);
            if (contact == null) return NotFound();

            return Ok(contact);
        }

        // POST: api/emergencycontact
        [HttpPost]
        public IActionResult Create([FromBody] EmergencyContact contact)
        {
            if (contact == null) return BadRequest();

            var newContact = _service.Create(contact);
            return CreatedAtAction(nameof(GetById), new { id = newContact.Id }, newContact);
        }

        // PUT: api/emergencycontact/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] EmergencyContact contact)
        {
            if (contact == null || id != contact.Id) return BadRequest();

            var updated = _service.Update(contact);
            if (!updated) return NotFound();

            return NoContent();
        }

        // DELETE: api/emergencycontact/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}