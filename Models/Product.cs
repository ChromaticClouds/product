namespace YourNamespace.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public int Count { get; set; }
        public string Status { get; set; }
        public DateTime InBound { get; set; }
        public int RegisterID { get; set; }
        public Register Register { get; set; } = null!;
    }
}