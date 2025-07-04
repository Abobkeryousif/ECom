﻿// <auto-generated />
using Ecom.Infrstrucure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecom.Infrstrucure.Data.Migrationss
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250310162835_null")]
    partial class @null
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ecom.Core.Entities.Product.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descrpition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descrpition = "test",
                            Name = "test"
                        });
                });

            modelBuilder.Entity("Ecom.Core.Entities.Product.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Photo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageName = "Test",
                            ProductId = 1
                        });
                });

            modelBuilder.Entity("Ecom.Core.Entities.Product.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Dscription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(33)
                        .HasColumnType("nvarchar(33)");

                    b.Property<decimal>("NewPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OldPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Dscription = "test",
                            Name = "Test",
                            NewPrice = 20m,
                            OldPrice = 10m
                        });
                });

            modelBuilder.Entity("Ecom.Core.Entities.Product.Photo", b =>
                {
                    b.HasOne("Ecom.Core.Entities.Product.Product", null)
                        .WithMany("photos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ecom.Core.Entities.Product.Product", b =>
                {
                    b.HasOne("Ecom.Core.Entities.Product.Categories", "Categories")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Ecom.Core.Entities.Product.Product", b =>
                {
                    b.Navigation("photos");
                });
#pragma warning restore 612, 618
        }
    }
}
