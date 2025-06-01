namespace Ayra.Application.dto
{
    public class MapMarkerCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Intensity { get; set; } // high, medium, low
        public double Radius { get; set; }
        public int CoordinateId { get; set; }
    }
}
