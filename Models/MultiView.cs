namespace YourNamespace.Models
{
    public class MultiView
    {
        public required List<Product> Products { get; set; }
        public required List<Inventory> Inventory { get; set; }
        public required List<Register> Register { get; set; }
    }
}