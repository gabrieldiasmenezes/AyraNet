using Ayra.Application.dto;
using Ayra.Domain.Entities;
using Ayra.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Ayra.Application.Services
{
    public class AlertService
    {
        private readonly ApplicationDbContext _context;

        public AlertService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Alert> CreateAsync(AlertCreateDto dto)
        {
            var alert = new Alert
            {
                Title = dto.Title,
                Description = dto.Description,
                Intensity = dto.Intensity,
                AlertDateTime = dto.AlertDateTime,
                Location = dto.Location,
                Radius = dto.Radius,
                EvacuationTime = dto.EvacuationTime,
                CoordinateId = dto.CoordinateId,
                MapMarkerId = dto.MapMarkerId
            };

            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();
            return alert;
        }

        public async Task<List<Alert>> GetAllAsync() => await _context.Alerts.ToListAsync();

        public async Task<Alert> GetByIdAsync(int id) => await _context.Alerts.FindAsync(id);

        public async Task<bool> UpdateAsync(int id, AlertCreateDto dto)
        {
            var alert = await _context.Alerts.FindAsync(id);
            if (alert == null) return false;

            alert.Title = dto.Title;
            alert.Description = dto.Description;
            alert.Intensity = dto.Intensity;
            alert.AlertDateTime = dto.AlertDateTime;
            alert.Location = dto.Location;
            alert.Radius = dto.Radius;
            alert.EvacuationTime = dto.EvacuationTime;
            alert.CoordinateId = dto.CoordinateId;
            alert.MapMarkerId = dto.MapMarkerId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var alert = await _context.Alerts.FindAsync(id);
            if (alert == null) return false;

            _context.Alerts.Remove(alert);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
