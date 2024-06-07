using Microsoft.EntityFrameworkCore;

namespace YourNamespace.Models
{
    public class ProductOrder {
        public int RegisterID { get; set; } 
        public int Quantity { get; set; }
        public string Status { get; set; }
        public DateTime OutBound { get; set; }
    }
}