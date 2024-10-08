﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzeriaInFornoWebApp.Data;

#nullable disable

namespace PizzeriaInFornoWebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240807105124_completo")]
    partial class completo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PizzeriaInFornoWebApp.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Funghi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Carciofi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sale"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Prosciutto"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Pomodoro"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Salsiccia"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Olio d'oliva"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Aglio"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Peperoni"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Mozzarella"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Acciughe"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Origano"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Pepe"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Cipolla"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Basilico"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Gorgonzola"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Rucola"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Tonno"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Zucchine"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Melanzane"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Spinaci"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Capperi"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Olive nere"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Pancetta"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Parmigiano"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Nduja"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Provolone"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Grana Padano"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Feta"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Bresaola"
                        });
                });

            modelBuilder.Entity("PizzeriaInFornoWebApp.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzeriaInFornoWebApp.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("PizzeriaInFornoWebApp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DeliveryTime")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeliveryTime = 10,
                            Name = "Pizza Margherita",
                            PhotoUrl = "images/Margherita.jpg",
                            Price = 5.00m
                        },
                        new
                        {
                            Id = 2,
                            DeliveryTime = 25,
                            Name = "Pizza Prosciutto Cotto",
                            PhotoUrl = "images/PizzaPCotto.jpg",
                            Price = 7.50m
                        },
                        new
                        {
                            Id = 3,
                            DeliveryTime = 20,
                            Name = "Pizza Diavola",
                            PhotoUrl = "images/Diavola.jpg",
                            Price = 8.00m
                        },
                        new
                        {
                            Id = 4,
                            DeliveryTime = 22,
                            Name = "Pizza Quattro Formaggi",
                            PhotoUrl = "images/QuattroFormaggi.jpg",
                            Price = 8.50m
                        },
                        new
                        {
                            Id = 5,
                            DeliveryTime = 25,
                            Name = "Pizza Capricciosa",
                            PhotoUrl = "images/Capricciosa.jpg",
                            Price = 9.00m
                        },
                        new
                        {
                            Id = 6,
                            DeliveryTime = 20,
                            Name = "Pizza Vegetariana",
                            PhotoUrl = "images/Vegetariana.jpg",
                            Price = 7.00m
                        },
                        new
                        {
                            Id = 7,
                            DeliveryTime = 24,
                            Name = "Pizza Tonno e Cipolla",
                            PhotoUrl = "images/TonnoCipolla.jpg",
                            Price = 8.00m
                        },
                        new
                        {
                            Id = 8,
                            DeliveryTime = 22,
                            Name = "Pizza Napoletana",
                            PhotoUrl = "images/Napoletana.jpg",
                            Price = 7.50m
                        },
                        new
                        {
                            Id = 9,
                            DeliveryTime = 23,
                            Name = "Pizza Boscaiola",
                            PhotoUrl = "images/Boscaiola.jpg",
                            Price = 8.50m
                        },
                        new
                        {
                            Id = 10,
                            DeliveryTime = 20,
                            Name = "Pizza Calzone",
                            PhotoUrl = "images/Calzone.jpg",
                            Price = 8.00m
                        },
                        new
                        {
                            Id = 11,
                            DeliveryTime = 25,
                            Name = "Pizza Salsiccia e Friarielli",
                            PhotoUrl = "images/SalsicciaFriarielli.jpg",
                            Price = 9.00m
                        },
                        new
                        {
                            Id = 12,
                            DeliveryTime = 27,
                            Name = "Pizza Quattro Stagioni",
                            PhotoUrl = "images/QuattroStagioni.jpg",
                            Price = 9.50m
                        },
                        new
                        {
                            Id = 13,
                            DeliveryTime = 23,
                            Name = "Pizza Ortolana",
                            PhotoUrl = "images/Ortolana.jpg",
                            Price = 8.00m
                        },
                        new
                        {
                            Id = 14,
                            DeliveryTime = 20,
                            Name = "Pizza Marinara",
                            PhotoUrl = "images/Marinara.jpg",
                            Price = 6.00m
                        },
                        new
                        {
                            Id = 15,
                            DeliveryTime = 30,
                            Name = "Pizza Americana",
                            PhotoUrl = "images/Americana.jpg",
                            Price = 10.00m
                        });
                });

            modelBuilder.Entity("PizzeriaInFornoWebApp.Models.ProductIngredient", b =>
                {
                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("ProductIngredients");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            IngredientId = 10
                        },
                        new
                        {
                            ProductId = 1,
                            IngredientId = 5
                        },
                        new
                        {
                            ProductId = 1,
                            IngredientId = 15
                        },
                        new
                        {
                            ProductId = 2,
                            IngredientId = 10
                        },
                        new
                        {
                            ProductId = 2,
                            IngredientId = 5
                        },
                        new
                        {
                            ProductId = 2,
                            IngredientId = 4
                        },
                        new
                        {
                            ProductId = 3,
                            IngredientId = 10
                        },
                        new
                        {
                            ProductId = 3,
                            IngredientId = 9
                        },
                        new
                        {
                            ProductId = 3,
                            IngredientId = 5
                        },
                        new
                        {
                            ProductId = 4,
                            IngredientId = 10
                        },
                        new
                        {
                            ProductId = 4,
                            IngredientId = 16
                        },
                        new
                        {
                            ProductId = 4,
                            IngredientId = 27
                        },
                        new
                        {
                            ProductId = 4,
                            IngredientId = 28
                        },
                        new
                        {
                            ProductId = 5,
                            IngredientId = 10
                        },
                        new
                        {
                            ProductId = 5,
                            IngredientId = 5
                        },
                        new
                        {
                            ProductId = 5,
                            IngredientId = 1
                        },
                        new
                        {
                            ProductId = 5,
                            IngredientId = 4
                        },
                        new
                        {
                            ProductId = 5,
                            IngredientId = 2
                        },
                        new
                        {
                            ProductId = 5,
                            IngredientId = 23
                        },
                        new
                        {
                            ProductId = 6,
                            IngredientId = 10
                        },
                        new
                        {
                            ProductId = 6,
                            IngredientId = 5
                        },
                        new
                        {
                            ProductId = 6,
                            IngredientId = 19
                        },
                        new
                        {
                            ProductId = 6,
                            IngredientId = 20
                        },
                        new
                        {
                            ProductId = 6,
                            IngredientId = 21
                        },
                        new
                        {
                            ProductId = 7,
                            IngredientId = 10
                        },
                        new
                        {
                            ProductId = 7,
                            IngredientId = 18
                        },
                        new
                        {
                            ProductId = 7,
                            IngredientId = 14
                        },
                        new
                        {
                            ProductId = 7,
                            IngredientId = 5
                        },
                        new
                        {
                            ProductId = 8,
                            IngredientId = 10
                        },
                        new
                        {
                            ProductId = 8,
                            IngredientId = 11
                        },
                        new
                        {
                            ProductId = 8,
                            IngredientId = 22
                        },
                        new
                        {
                            ProductId = 8,
                            IngredientId = 5
                        },
                        new
                        {
                            ProductId = 9,
                            IngredientId = 10
                        },
                        new
                        {
                            ProductId = 9,
                            IngredientId = 6
                        },
                        new
                        {
                            ProductId = 9,
                            IngredientId = 1
                        },
                        new
                        {
                            ProductId = 9,
                            IngredientId = 5
                        },
                        new
                        {
                            ProductId = 10,
                            IngredientId = 10
                        },
                        new
                        {
                            ProductId = 10,
                            IngredientId = 4
                        },
                        new
                        {
                            ProductId = 10,
                            IngredientId = 13
                        },
                        new
                        {
                            ProductId = 11,
                            IngredientId = 10
                        },
                        new
                        {
                            ProductId = 11,
                            IngredientId = 6
                        },
                        new
                        {
                            ProductId = 11,
                            IngredientId = 21
                        },
                        new
                        {
                            ProductId = 12,
                            IngredientId = 10
                        },
                        new
                        {
                            ProductId = 12,
                            IngredientId = 5
                        },
                        new
                        {
                            ProductId = 12,
                            IngredientId = 1
                        },
                        new
                        {
                            ProductId = 12,
                            IngredientId = 4
                        },
                        new
                        {
                            ProductId = 12,
                            IngredientId = 2
                        },
                        new
                        {
                            ProductId = 13,
                            IngredientId = 10
                        },
                        new
                        {
                            ProductId = 13,
                            IngredientId = 19
                        },
                        new
                        {
                            ProductId = 13,
                            IngredientId = 20
                        },
                        new
                        {
                            ProductId = 13,
                            IngredientId = 5
                        },
                        new
                        {
                            ProductId = 14,
                            IngredientId = 5
                        },
                        new
                        {
                            ProductId = 14,
                            IngredientId = 7
                        },
                        new
                        {
                            ProductId = 14,
                            IngredientId = 8
                        },
                        new
                        {
                            ProductId = 14,
                            IngredientId = 12
                        },
                        new
                        {
                            ProductId = 15,
                            IngredientId = 10
                        },
                        new
                        {
                            ProductId = 15,
                            IngredientId = 9
                        },
                        new
                        {
                            ProductId = 15,
                            IngredientId = 24
                        },
                        new
                        {
                            ProductId = 15,
                            IngredientId = 5
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzeriaInFornoWebApp.Models.OrderItem", b =>
                {
                    b.HasOne("PizzeriaInFornoWebApp.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzeriaInFornoWebApp.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PizzeriaInFornoWebApp.Models.ProductIngredient", b =>
                {
                    b.HasOne("PizzeriaInFornoWebApp.Models.Ingredient", "Ingredient")
                        .WithMany("ProductIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzeriaInFornoWebApp.Models.Product", "Product")
                        .WithMany("ProductIngredients")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PizzeriaInFornoWebApp.Models.Ingredient", b =>
                {
                    b.Navigation("ProductIngredients");
                });

            modelBuilder.Entity("PizzeriaInFornoWebApp.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("PizzeriaInFornoWebApp.Models.Product", b =>
                {
                    b.Navigation("ProductIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
