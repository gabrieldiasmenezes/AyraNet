using System.Collections.Generic;

namespace Ayra.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } // UNIQUE
        public string Password { get; set; }
        public string Phone { get; set; } // UNIQUE
        public int CoordinateId { get; set; }

        // Relacionamento 1:N
        public Coordinate? Coordinate { get; set; }

        // Relacionamento N:M via EmergencyUser
         public ICollection<EmergencyUser> EmergencyUsers { get; set; } = new List<EmergencyUser>();
    }
}