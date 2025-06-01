using Ayra.Application.dto;
using Ayra.Domain.Entities;
using Ayra.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Ayra.Application.Services
{
    public class SafeTipService
    {
        private readonly ApplicationDbContext _context;

        public SafeTipService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SafeTip> CreateAsync(SafeTipCreateDto dto)
        {
            var tip = new SafeTip
            {
                Tip = dto.Tip,
                AlertId = dto.AlertId
            };

            _context.SafeTips.Add(tip);
            await _context.SaveChangesAsync();
            return tip;
        }

        public async Task<List<SafeTip>> GetAllAsync() => await _context.SafeTips.ToListAsync();

        public async Task<SafeTip> GetByIdAsync(int id) => await _context.SafeTips.FindAsync(id);

        public async Task<bool> UpdateAsync(int id, SafeTipCreateDto dto)
        {
            var tip = await _context.SafeTips.FindAsync(id);
            if (tip == null) return false;

            tip.Tip = dto.Tip;
            tip.AlertId = dto.AlertId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tip = await _context.SafeTips.FindAsync(id);
            if (tip == null) return false;

            _context.SafeTips.Remove(tip);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
