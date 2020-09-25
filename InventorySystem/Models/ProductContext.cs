using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public partial class ProductContext : DbContext
    {
        public ProductContext()
        {

        }

        public ProductContext(DbContextOptions<ProductContext> options) : base (options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=mvc_inventory", x => x.ServerVersion("10.4.14-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");

                entity.HasData(
                    new Product()
                    {
                        ID = -1,
                        Name = "Renberget",
                        Quantity = 5,
                        IsDiscontinued = false
                    },
                    new Product()
                    {
                        ID = -2,
                        Name = "Loberget",
                        Quantity = 0,
                        IsDiscontinued = false
                    },
                    new Product()
                    {
                        ID = -3,
                        Name = "Loberget",
                        Quantity = 0,
                        IsDiscontinued = true
                    });
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
