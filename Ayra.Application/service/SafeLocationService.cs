using Ayra.Application.dto;
using Ayra.Domain.Entities;
using Ayra.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Ayra.Application.Services
{
    public class SafeLocationService
    {
        private readonly ApplicationDbContext _context;

        public SafeLocationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SafeLocation> CreateAsync(SafeLocationCreateDto dto)
        {
            var location = new SafeLocation
            {
                Location = dto.Location,
                AlertId = dto.AlertId
            };

            _context.SafeLocations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<List<SafeLocation>> GetAllAsync() => await _context.SafeLocations.ToListAsync();

        public async Task<SafeLocation> GetByIdAsync(int id) => await _context.SafeLocations.FindAsync(id);

        public async Task<bool> UpdateAsync(int id, SafeLocationCreateDto dto)
        {
            var location = await _context.SafeLocations.FindAsync(id);
            if (location == null) return false;

            location.Location = dto.Location;
            location.AlertId = dto.AlertId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var location = await _context.SafeLocations.FindAsync(id);
            if (location == null) return false;

            _context.SafeLocations.Remove(location);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
