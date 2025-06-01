using Ayra.Domain.Entities;
using Ayra.Infrastructure.Context;

namespace Ayra.Application.Services
{
    public class EmergencyContactService
    {
        private readonly ApplicationDbContext _context;

        public EmergencyContactService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EmergencyContact> GetAll()
        {
            return _context.EmergencyContacts.ToList();
        }

        public EmergencyContact GetById(int id)
        {
            return _context.EmergencyContacts.Find(id);
        }

        public EmergencyContact Create(EmergencyContact contact)
        {
            _context.EmergencyContacts.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public bool Update(EmergencyContact contact)
        {
            var existing = _context.EmergencyContacts.Find(contact.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(contact);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var contact = _context.EmergencyContacts.Find(id);
            if (contact == null) return false;

            _context.EmergencyContacts.Remove(contact);
            _context.SaveChanges();
            return true;
        }
    }
}