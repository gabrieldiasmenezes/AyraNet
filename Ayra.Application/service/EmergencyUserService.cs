using Ayra.Domain.Entities;
using Ayra.Infrastructure.Context;
using Ayra.Application.dto;

namespace Ayra.Application.Services
{
    public class EmergencyUserService
    {
        private readonly ApplicationDbContext _context;

        public EmergencyUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EmergencyUser> GetAll()
        {
            return _context.EmergencyUsers.ToList();
        }

        public EmergencyUser GetById(int userId, int contactId)
        {
            return _context.EmergencyUsers.Find(userId, contactId);
        }

        public EmergencyUser Create(EmergencyUserCreateDto dto)
        {
            var entity = new EmergencyUser
            {
                UserId = dto.UserId,
                EmergencyContactId = dto.EmergencyContactId
            };

            _context.EmergencyUsers.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Update(EmergencyUser emergencyUser)
        {
            var existing = _context.EmergencyUsers.Find(emergencyUser.UserId, emergencyUser.EmergencyContactId);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(emergencyUser);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int userId, int contactId)
        {
            var entity = _context.EmergencyUsers.Find(userId, contactId);
            if (entity == null) return false;

            _context.EmergencyUsers.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}
