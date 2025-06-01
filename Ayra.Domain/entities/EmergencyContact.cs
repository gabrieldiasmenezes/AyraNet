namespace Ayra.Domain.Entities
{
    public class EmergencyContact
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Phone { get; set; } 
        public ICollection<EmergencyUser> EmergencyUsers { get; set; } = new List<EmergencyUser>();
    }
}