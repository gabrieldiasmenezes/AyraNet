using Ayra.Application.dto;
using Ayra.Application.Services;
using Ayra.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ayra.API.Controllers
{
    [ApiController]
    [Route("alert")]
    public class AlertController : ControllerBase
    {
        private readonly AlertService _service;

        public AlertController(AlertService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<Alert>> Create([FromBody] AlertCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Alert>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alert>> GetById(int id)
        {
            var alert = await _service.GetByIdAsync(id);
            if (alert == null) return NotFound();
            return Ok(alert);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AlertCreateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
