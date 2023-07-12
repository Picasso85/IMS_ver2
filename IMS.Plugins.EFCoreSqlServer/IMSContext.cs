using IMS.CoreBusiness;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace IMS.Plugins.EFCoreSqlServer
{
    public class IMSContext : DbContext
    {
        public IMSContext(DbContextOptions<IMSContext> options):base(options)  
        { 
        
        
        }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInventory> ProductInventories { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<ProductTransaction> ProductTransactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductInventory>()
                .HasKey(pi => new { pi.ProductId, pi.InventoryId });

            modelBuilder.Entity<ProductInventory>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductInventories)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductInventory>()
                .HasOne(pi => pi.Inventory)
                .WithMany(i => i.ProductInventories)
                .HasForeignKey(pi => pi.InventoryId);

            // seeding data

            modelBuilder.Entity<Inventory>().HasData(

                new Inventory { InventoryId = 1, InventoryName = "Case S-49", Quantity = 12, Price = 129.99 },
                new Inventory { InventoryId = 2, InventoryName = "M/B-X1333", Quantity = 8, Price = 110.99 },
                new Inventory { InventoryId = 3, InventoryName = "M/B-X1533", Quantity = 6, Price = 120.99 },
                new Inventory { InventoryId = 4, InventoryName = "M/B-X1933", Quantity = 4, Price = 199.99 },
                new Inventory { InventoryId = 5, InventoryName = "M/B-X2533", Quantity = 45, Price = 129.99 },
                new Inventory { InventoryId = 6, InventoryName = "M/B-X2733", Quantity = 3, Price = 114.99 },
                new Inventory { InventoryId = 7, InventoryName = "M/B-X3033", Quantity = 4, Price = 129.99 },
                new Inventory { InventoryId = 8, InventoryName = "M/B-X3133", Quantity = 15, Price = 179.99 },
                new Inventory { InventoryId = 9, InventoryName = "M/B-X3233", Quantity = 7, Price = 164.99 },
                new Inventory { InventoryId = 10, InventoryName = "M/B-X4333", Quantity = 15, Price = 229.99 },
                new Inventory { InventoryId = 11, InventoryName = "CPU I-30", Quantity = 6, Price = 579.99 },
                new Inventory { InventoryId = 12, InventoryName = "CPU I-29", Quantity = 8, Price = 479.99 },
                new Inventory { InventoryId = 13, InventoryName = "CPU X-400", Quantity = 7, Price = 879.99 },
                new Inventory { InventoryId = 14, InventoryName = "Case X-10", Quantity = 4, Price = 100.99 },
                new Inventory { InventoryId = 15, InventoryName = "Case X-21", Quantity = 20, Price = 129.99 },
                new Inventory { InventoryId = 16, InventoryName = "DDR10 450GB", Quantity = 68, Price = 129.99 },
                new Inventory { InventoryId = 17, InventoryName = "DDR12 600GB", Quantity = 50, Price = 159.99 },
                new Inventory { InventoryId = 18, InventoryName = "SSD 150TB", Quantity = 12, Price = 199.99 },
                new Inventory { InventoryId = 19, InventoryName = "RTX-7090Ti 100GB", Quantity = 12, Price = 899.99 },
                new Inventory { InventoryId = 20, InventoryName = "P-S 2000 Wat", Quantity = 46, Price = 159.99 },
                new Inventory { InventoryId = 21, InventoryName = "P-S 2200 Wat", Quantity = 12, Price = 199.99 },
                new Inventory { InventoryId = 22, InventoryName = "P-S 2500 Wat", Quantity = 8, Price = 210.99 },
                new Inventory { InventoryId = 23, InventoryName = "SSD 100TB", Quantity = 6, Price = 60.99 },
                new Inventory { InventoryId = 24, InventoryName = "SSD 200TB", Quantity = 4, Price = 111.99 },
                new Inventory { InventoryId = 25, InventoryName = "SSD 2500TB", Quantity = 45, Price = 169.99 },
                new Inventory { InventoryId = 26, InventoryName = "SSD 300TB", Quantity = 3, Price = 174.99 },
                new Inventory { InventoryId = 27, InventoryName = "SSD 3500TB", Quantity = 4, Price = 189.99 },
                new Inventory { InventoryId = 28, InventoryName = "RTX-5090Ti 80GB", Quantity = 15, Price = 579.99 },
                new Inventory { InventoryId = 29, InventoryName = "RTX-5090Ti 90GB", Quantity = 7, Price = 664.99 },
                new Inventory { InventoryId = 30, InventoryName = "M/B-X4344", Quantity = 15, Price = 229.99 },
                new Inventory { InventoryId = 31, InventoryName = "CPU Z-30", Quantity = 6, Price = 579.99 },
                new Inventory { InventoryId = 32, InventoryName = "CPU Z-29", Quantity = 8, Price = 479.99 },
                new Inventory { InventoryId = 33, InventoryName = "CPU K-410", Quantity = 7, Price = 879.99 },
                new Inventory { InventoryId = 34, InventoryName = "Case X-14", Quantity = 4, Price = 100.99 },
                new Inventory { InventoryId = 35, InventoryName = "Case X-26", Quantity = 20, Price = 129.99 },
                new Inventory { InventoryId = 36, InventoryName = "DDR10 350GB", Quantity = 68, Price = 129.99 },
                new Inventory { InventoryId = 37, InventoryName = "DDR12 200GB", Quantity = 50, Price = 159.99 },
                new Inventory { InventoryId = 38, InventoryName = "SSD 400TB", Quantity = 12, Price = 199.99 },
                new Inventory { InventoryId = 39, InventoryName = "RTX-6090Ti 100GB", Quantity = 12, Price = 799.99 },
                new Inventory { InventoryId = 40, InventoryName = "P-S 2500 Wat", Quantity = 46, Price = 159.99 }

                );

            modelBuilder.Entity<Product>().HasData(

                new Product() { ProductId = 1, ProductName = "Custom PC-CR1000", Quantity = 1, Price = 2199 },
                new Product() { ProductId = 2, ProductName = "Custom PC-CR2000", Quantity = 1, Price = 2299 },
                new Product() { ProductId = 3, ProductName = "Custom PC-CR3000", Quantity = 1, Price = 2599 },
                new Product() { ProductId = 4, ProductName = "Custom PC-CR4000", Quantity = 1, Price = 2699 },
                new Product() { ProductId = 5, ProductName = "Custom PC-CR5000", Quantity = 1, Price = 2799 },
                new Product() { ProductId = 6, ProductName = "Custom PC-CR6000", Quantity = 1, Price = 2299 }

                );

            // here is place for build customs attributes... 

            modelBuilder.Entity<ProductInventory>().HasData(

                // Custom PC-CR1000 

                new ProductInventory() { ProductId = 1, InventoryId = 1, InventoryQuantity = 1 },   // case
                new ProductInventory() { ProductId = 1, InventoryId = 2, InventoryQuantity = 1 },   // Motherboard
                new ProductInventory() { ProductId = 1, InventoryId = 11, InventoryQuantity = 1 },  // cpu
                new ProductInventory() { ProductId = 1, InventoryId = 16, InventoryQuantity = 1 },  // memory
                new ProductInventory() { ProductId = 1, InventoryId = 18, InventoryQuantity = 1 },  // ssd
                new ProductInventory() { ProductId = 1, InventoryId = 28, InventoryQuantity = 1 },  // Graphic Card
                new ProductInventory() { ProductId = 1, InventoryId = 40, InventoryQuantity = 1 }   // Power Supply
                );
        }
    }
}