using Ayra.Application.dto;
using Ayra.Domain.Entities;
using Ayra.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Ayra.Application.Services
{
    public class MapMarkerService
    {
        private readonly ApplicationDbContext _context;

        public MapMarkerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MapMarker> CreateAsync(MapMarkerCreateDto dto)
        {
            var marker = new MapMarker
            {
                Title = dto.Title,
                Description = dto.Description,
                Intensity = dto.Intensity,
                Radius = dto.Radius,
                CoordinateId = dto.CoordinateId
            };

            _context.MapMarkers.Add(marker);
            await _context.SaveChangesAsync();
            return marker;
        }

        public async Task<List<MapMarker>> GetAllAsync() => await _context.MapMarkers.ToListAsync();

        public async Task<MapMarker> GetByIdAsync(int id) =>
            await _context.MapMarkers.FindAsync(id);

        public async Task<bool> UpdateAsync(int id, MapMarkerCreateDto dto)
        {
            var marker = await _context.MapMarkers.FindAsync(id);
            if (marker == null) return false;

            marker.Title = dto.Title;
            marker.Description = dto.Description;
            marker.Intensity = dto.Intensity;
            marker.Radius = dto.Radius;
            marker.CoordinateId = dto.CoordinateId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var marker = await _context.MapMarkers.FindAsync(id);
            if (marker == null) return false;

            _context.MapMarkers.Remove(marker);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
