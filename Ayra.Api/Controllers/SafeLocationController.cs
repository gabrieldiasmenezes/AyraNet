using Ayra.Application.dto;
using Ayra.Application.Services;
using Ayra.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ayra.API.Controllers
{
    [ApiController]
    [Route("safe-location")]
    public class SafeLocationController : ControllerBase
    {
        private readonly SafeLocationService _service;

        public SafeLocationController(SafeLocationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<SafeLocation>> Create([FromBody] SafeLocationCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<ActionResult<List<SafeLocation>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SafeLocation>> GetById(int id)
        {
            var location = await _service.GetByIdAsync(id);
            if (location == null) return NotFound();
            return Ok(location);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SafeLocationCreateDto dto)
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
