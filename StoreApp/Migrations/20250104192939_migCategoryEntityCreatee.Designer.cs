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
    [Migration("20250104192939_migCategoryEntityCreatee")]
    partial class migCategoryEntityCreatee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoreApp.Data.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CategoryId");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Description = "Telefonlarrrrr",
                            Name = "Telefon",
                            Url = "telefon"
                        },
                        new
                        {
                            CategoryId = 2,
                            Description = "Elektronik",
                            Name = "Elektronik",
                            Url = "elektronik"
                        },
                        new
                        {
                            CategoryId = 3,
                            Description = "Kozmetikkkk",
                            Name = "Kozmetik",
                            Url = "kozmetik"
                        });
                });

            modelBuilder.Entity("StoreApp.Data.Concrete.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "Nice Phone",
                            Name = "Iphone",
                            Price = 1453m,
                            ProductImage = "UrunResmi"
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "Phone",
                            Name = "Apple",
                            Price = 1453m,
                            ProductImage = "UrunResmi"
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "Bad Phone",
                            Name = "Samsung",
                            Price = 7895m,
                            ProductImage = "UrunResmi"
                        },
                        new
                        {
                            ProductId = 4,
                            Description = "Exelent Phone",
                            Name = "Vestel",
                            Price = 7822m,
                            ProductImage = "UrunResmi"
                        },
                        new
                        {
                            ProductId = 5,
                            Description = "Nickie Phone",
                            Name = "Xaomi",
                            Price = 8000m,
                            ProductImage = "UrunResmi"
                        },
                        new
                        {
                            ProductId = 6,
                            Description = "Nice Cihaz",
                            Name = "Regal",
                            Price = 6000m,
                            ProductImage = "UrunResmi"
                        });
                });

            modelBuilder.Entity("StoreApp.Data.Concrete.ProductCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategory");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 2
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 3
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 4
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 5
                        },
                        new
                        {
                            CategoryId = 1,
                            ProductId = 6
                        });
                });

            modelBuilder.Entity("StoreApp.Data.Concrete.ProductCategory", b =>
                {
                    b.HasOne("StoreApp.Data.Concrete.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreApp.Data.Concrete.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
