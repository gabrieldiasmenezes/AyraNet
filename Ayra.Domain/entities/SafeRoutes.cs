namespace Ayra.Domain.Entities
{
    public class SafeRoute
    {
        public int Id { get; set; }
        public string Route { get; set; }
        public int AlertId { get; set; }

        // Relacionamento N:1
        public Alert Alert { get; set; }
    }
}