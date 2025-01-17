﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreApp.Data.Concrete;

#nullable disable

namespace StoreApp.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20241226215913_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoreApp.Data.Concrete.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Category = "Telefon",
                            Description = "Nice Phone",
                            Name = "Iphone",
                            Price = 1453m
                        },
                        new
                        {
                            ProductId = 2,
                            Category = "Telefon",
                            Description = "Phone",
                            Name = "Apple",
                            Price = 1453m
                        },
                        new
                        {
                            ProductId = 3,
                            Category = "Telefon",
                            Description = "Bad Phone",
                            Name = "Samsung",
                            Price = 7895m
                        },
                        new
                        {
                            ProductId = 4,
                            Category = "Telefon",
                            Description = "Exelent Phone",
                            Name = "Vestel",
                            Price = 7822m
                        },
                        new
                        {
                            ProductId = 5,
                            Category = "Telefon",
                            Description = "Nickie Phone",
                            Name = "Xaomi",
                            Price = 8000m
                        },
                        new
                        {
                            ProductId = 6,
                            Category = "Beyaz Eşya",
                            Description = "Nice Cihaz",
                            Name = "Regal",
                            Price = 6000m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
