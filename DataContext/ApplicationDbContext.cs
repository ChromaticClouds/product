using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

namespace YourNamespace.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Register>()
                .HasMany(o => o.Products)
                .WithOne(o => o.Register)
                .HasForeignKey(o => o.RegisterID)
                .IsRequired();

            modelBuilder.Entity<Register>()
                .HasOne(e => e.Inventory)
                .WithOne(e => e.Register)
                .HasForeignKey<Inventory>(e => e.RegisterID)
                .IsRequired();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Register> Register { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
    }
}
