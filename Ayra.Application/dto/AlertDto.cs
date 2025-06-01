
namespace Ayra.Application.dto
{
    public class AlertCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Intensity { get; set; }
        public DateTime AlertDateTime { get; set; }
        public string Location { get; set; }
        public double Radius { get; set; }
        public string EvacuationTime { get; set; }
        public int CoordinateId { get; set; }
        public int MapMarkerId { get; set; }
    }
}
