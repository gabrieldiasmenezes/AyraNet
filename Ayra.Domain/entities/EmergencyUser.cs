namespace Ayra.Domain.Entities
{
    public class EmergencyUser
    {
        public int EmergencyContactId { get; set; }
        public int UserId { get; set; }

        // Relacionamentos
        public EmergencyContact EmergencyContact { get; set; }
        public User User { get; set; }
    }
}