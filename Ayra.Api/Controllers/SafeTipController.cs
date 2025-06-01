using Ayra.Application.dto;
using Ayra.Application.Services;
using Ayra.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ayra.API.Controllers
{
    [ApiController]
    [Route("safe-tip")]
    public class SafeTipController : ControllerBase
    {
        private readonly SafeTipService _service;

        public SafeTipController(SafeTipService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<SafeTip>> Create([FromBody] SafeTipCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<ActionResult<List<SafeTip>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SafeTip>> GetById(int id)
        {
            var tip = await _service.GetByIdAsync(id);
            if (tip == null) return NotFound();
            return Ok(tip);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SafeTipCreateDto dto)
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
