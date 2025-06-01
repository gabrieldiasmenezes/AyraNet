namespace Ayra.Domain.Entities
{
    public class SafeLocation
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int AlertId { get; set; }

        // Relacionamento N:1
        public Alert Alert { get; set; }
    }
}