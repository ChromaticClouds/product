namespace YourNamespace.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public int RegisterID { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime LastUpdated { get; set; }
        public Register Register { get; set; } = null!;
    }
}