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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new List<Product>() {
                    new() { ProductId=1,Name="Iphone",Price=1453,Description="Nice Phone",Category="Telefon"},
                    new() { ProductId=2,Name="Apple",Price=1453,Description="Phone",Category="Telefon"},
                    new() { ProductId=3,Name="Samsung",Price=7895,Description="Bad Phone",Category="Telefon"},
                    new() { ProductId=4,Name="Vestel",Price=7822,Description="Exelent Phone",Category="Telefon"},
                    new() { ProductId=5,Name="Xaomi",Price=8000,Description="Nickie Phone",Category="Telefon"},
                    new() { ProductId=6,Name="Regal",Price=6000,Description="Nice Cihaz",Category="Beyaz Eşya"},
                }
            );
        }
    }
}
