using Microsoft.AspNetCore.Mvc;
using Ayra.Domain.Entities;

namespace Ayra.Api.Controllers
{
    [ApiController]
    [Route("coordinates")]
    public class CoordinatesController : ControllerBase
    {
        private readonly CoordinateService _coordinateService;

        public CoordinatesController(CoordinateService coordinateService)
        {
            _coordinateService = coordinateService;
        }

        // GET: api/coordinates
        [HttpGet]
        public IActionResult GetAll()
        {
            var coordinates = _coordinateService.GetAll();
            return Ok(coordinates);
        }

        // GET: api/coordinates/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var coordinate = _coordinateService.GetById(id);
            if (coordinate == null) return NotFound();

            return Ok(coordinate);
        }

        // POST: api/coordinates
        [HttpPost]
        public IActionResult Create([FromBody] Coordinate coordinate)
        {
            if (coordinate == null) return BadRequest();

            var newCoordinate = _coordinateService.Create(coordinate);
            return CreatedAtAction(nameof(GetById), new { id = newCoordinate.Id }, newCoordinate);
        }

        // PUT: api/coordinates/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Coordinate coordinate)
        {
            if (coordinate == null || id != coordinate.Id) return BadRequest();

            var updated = _coordinateService.Update(coordinate);
            if (!updated) return NotFound();

            return NoContent();
        }

        // DELETE: api/coordinates/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _coordinateService.Delete(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}