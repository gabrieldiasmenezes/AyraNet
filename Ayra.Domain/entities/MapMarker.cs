namespace Ayra.Domain.Entities
{
    public class MapMarker
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Intensity { get; set; } // high, medium, low
        public double Radius { get; set; } // CHECK > 0
        public int CoordinateId { get; set; }

        // Relacionamento 1:N
        public Coordinate Coordinate { get; set; }
    }
}