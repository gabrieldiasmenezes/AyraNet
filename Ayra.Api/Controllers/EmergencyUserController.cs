using Microsoft.AspNetCore.Mvc;
using Ayra.Application.Services;
using Ayra.Domain.Entities;
using Ayra.Application.dto;

namespace Ayra.Api.Controllers
{
    [ApiController]
    [Route("emergencyUser")]
    public class EmergencyUserController : ControllerBase
    {
        private readonly EmergencyUserService _service;

        public EmergencyUserController(EmergencyUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _service.GetAll();
            return Ok(items);
        }

        [HttpGet("{userId}/{contactId}")]
        public IActionResult GetById(int userId, int contactId)
        {
            var item = _service.GetById(userId, contactId);
            if (item == null) return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EmergencyUserCreateDto dto)
        {
            if (dto == null) return BadRequest();

            try
            {
                var newItem = _service.Create(dto);
                return CreatedAtAction(nameof(GetById), new { userId = newItem.UserId, contactId = newItem.EmergencyContactId }, newItem);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "Erro ao criar relação" });
            }
        }

        [HttpPut("{userId}/{contactId}")]
        public IActionResult Update(int userId, int contactId, [FromBody] EmergencyUser emergencyUser)
        {
            if (emergencyUser == null || userId != emergencyUser.UserId || contactId != emergencyUser.EmergencyContactId)
                return BadRequest();

            var updated = _service.Update(emergencyUser);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{userId}/{contactId}")]
        public IActionResult Delete(int userId, int contactId)
        {
            var deleted = _service.Delete(userId, contactId);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
