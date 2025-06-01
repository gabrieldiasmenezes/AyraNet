using System;

namespace Ayra.Domain.Entities
{
    public class Coordinate
    {
        public int Id { get; set; }
        public double Latitude { get; set; } // NUMBER(9,6)
        public double Longitude { get; set; } // NUMBER(9,6)
        public DateTime DateCoordinate { get; set; } // DATE
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}