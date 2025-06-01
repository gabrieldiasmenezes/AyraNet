namespace Ayra.Domain.Entities
{
    public class SafeTip
    {
        public int Id { get; set; }
        public string Tip { get; set; }
        public int AlertId { get; set; }

        // Relacionamento N:1
        public Alert Alert { get; set; }
    }
}