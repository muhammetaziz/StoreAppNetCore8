using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Concrete
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Contact> Contacts => Set<Contact>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Categories)
                .WithMany(e => e.Products)
                .UsingEntity<ProductCategory>();

            modelBuilder.Entity<Category>()
                .HasIndex(u => u.Url)
                .IsUnique();

            modelBuilder.Entity<Product>().HasData(
                new List<Product>() {
                    new() { ProductId=1,Name="Iphone",Price=1453,Description="Nice Phone",ProductImage="UrunResmi"},
                    new() { ProductId=2,Name="Apple",Price=1453,Description="Phone",ProductImage="UrunResmi"},
                    new() { ProductId=3,Name="Samsung",Price=7895,Description="Bad Phone",ProductImage="UrunResmi"},
                    new() { ProductId=4,Name="Vestel",Price=7822,Description="Exelent Phone",ProductImage="UrunResmi"},
                    new() { ProductId=5,Name="Xaomi",Price=8000,Description="Nickie Phone",ProductImage="UrunResmi"},
                    new() { ProductId=6,Name="Regal",Price=6000,Description="Nice Cihaz",ProductImage="UrunResmi"},
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new List<Category>(){
                    new() { CategoryId=1,Name="Telefon",Description="Telefonlarrrrr",Url="telefon" },
                    new() { CategoryId=2,Name="Elektronik",Description="Elektronik",Url="elektronik" },
                    new() { CategoryId=3,Name="Kozmetik",Description="Kozmetikkkk",Url="kozmetik" },

                    }
            );

            modelBuilder.Entity<ProductCategory>().HasData(
               new List<ProductCategory>(){
                    new() { CategoryId=1,ProductId=1},
                    new() { CategoryId=2,ProductId=2},
                    new() { CategoryId=3,ProductId=3},
                    new() { CategoryId=3,ProductId=4},
                    new() { CategoryId=3,ProductId=5},
                    new() {CategoryId=1,ProductId=6},

                   }
           );
        }
    }
}
