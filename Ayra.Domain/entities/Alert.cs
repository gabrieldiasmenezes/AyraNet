using System;

namespace Ayra.Domain.Entities
{
    public class Alert
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Intensity { get; set; } // high, medium, low
        public DateTime AlertDateTime { get; set; } // TIMESTAMP WITH TIME ZONE
        public string Location { get; set; }
        public double Radius { get; set; }
        public string EvacuationTime { get; set; }
        public int CoordinateId { get; set; }
        public int MapMarkerId { get; set; }

        // Relacionamentos N:1
        public Coordinate Coordinate { get; set; }
        public MapMarker MapMarker { get; set; }

        // Relacionamentos para entidades dependentes
        public ICollection<SafeRoute> SafeRoutes { get; set; }
        public ICollection<SafeLocation> SafeLocations { get; set; }
        public ICollection<SafeTip> SafeTips { get; set; }
    }
}