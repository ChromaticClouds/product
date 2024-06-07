namespace YourNamespace.Models
{
    public class RegisterProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public long SalePrice { get; set; }
        public long OriginPrice { get; set; }
        public DateTime Date { get; set; }
    }

    public class ProductDeleteRequest
    {
        public int RegisterID { get; set; }
    }

    // Principal (parent)
    public class Register {
        public int RegisterID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public long SalePrice { get; set; }
        public long OriginPrice { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Product> Products { get; } = new List<Product>(); // Collection navigation containing depedents
        public Inventory? Inventory { get; set; }
    }
}