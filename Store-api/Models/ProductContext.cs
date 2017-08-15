using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProductStoreAPI.Models
{
    public class ProductContext : DbContext
    {
        //Constructor argument necessary to add dbcontext to dependency injection
        public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ProductStore.db");
        }

        //Setting foreign keys(attribute notation isn't available for Core version yet)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Category)
                        .WithMany(c => c.Products)
                        .HasForeignKey(p => p.CategoryID)
                        .HasConstraintName("ForeignKey_Product_Category").OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderItem>()
                        .HasOne(o => o.Product)
                        .WithMany()
                        .HasForeignKey(o => o.ProductID)
                        .HasConstraintName("ForeignKey_OrderItem_Product").OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderItem>();
        }

    }
}
