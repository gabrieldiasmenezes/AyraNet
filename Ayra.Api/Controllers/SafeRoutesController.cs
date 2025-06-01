using Ayra.Application.dto;
using Ayra.Application.Services;
using Ayra.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ayra.API.Controllers
{
    [ApiController]
    [Route("safe-routes")]
    public class SafeRouteController : ControllerBase
    {
        private readonly SafeRouteService _service;

        public SafeRouteController(SafeRouteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<SafeRoute>> Create([FromBody] SafeRouteCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<ActionResult<List<SafeRoute>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SafeRoute>> GetById(int id)
        {
            var route = await _service.GetByIdAsync(id);
            if (route == null) return NotFound();
            return Ok(route);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SafeRouteCreateDto dto)
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
