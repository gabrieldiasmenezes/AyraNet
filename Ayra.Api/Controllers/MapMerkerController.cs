using Ayra.Application.dto;
using Ayra.Application.Services;
using Ayra.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ayra.API.Controllers
{
    [ApiController]
    [Route("map-marker")]
    public class MapMarkerController : ControllerBase
    {
        private readonly MapMarkerService _service;

        public MapMarkerController(MapMarkerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<MapMarker>> Create([FromBody] MapMarkerCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<ActionResult<List<MapMarker>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MapMarker>> GetById(int id)
        {
            var marker = await _service.GetByIdAsync(id);
            if (marker == null) return NotFound();
            return Ok(marker);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MapMarkerCreateDto dto)
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
