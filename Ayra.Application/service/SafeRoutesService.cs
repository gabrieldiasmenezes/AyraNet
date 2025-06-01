using Ayra.Application.dto;
using Ayra.Domain.Entities;
using Ayra.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Ayra.Application.Services
{
    public class SafeRouteService
    {
        private readonly ApplicationDbContext _context;

        public SafeRouteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SafeRoute> CreateAsync(SafeRouteCreateDto dto)
        {
            var route = new SafeRoute
            {
                Route = dto.Route,
                AlertId = dto.AlertId
            };

            _context.SafeRoutes.Add(route);
            await _context.SaveChangesAsync();
            return route;
        }

        public async Task<List<SafeRoute>> GetAllAsync() => await _context.SafeRoutes.ToListAsync();

        public async Task<SafeRoute> GetByIdAsync(int id) => await _context.SafeRoutes.FindAsync(id);

        public async Task<bool> UpdateAsync(int id, SafeRouteCreateDto dto)
        {
            var route = await _context.SafeRoutes.FindAsync(id);
            if (route == null) return false;

            route.Route = dto.Route;
            route.AlertId = dto.AlertId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var route = await _context.SafeRoutes.FindAsync(id);
            if (route == null) return false;

            _context.SafeRoutes.Remove(route);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
