using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzeriaInFornoWebApp.Models;

namespace PizzeriaInFornoWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Funghi" },
                new Ingredient { Id = 2, Name = "Carciofi" },
                new Ingredient { Id = 3, Name = "Sale" },
                new Ingredient { Id = 4, Name = "Prosciutto" },
                new Ingredient { Id = 5, Name = "Pomodoro" },
                new Ingredient { Id = 6, Name = "Salsiccia" },
                new Ingredient { Id = 7, Name = "Olio d'oliva" },
                new Ingredient { Id = 8, Name = "Aglio" },
                new Ingredient { Id = 9, Name = "Peperoni" },
                new Ingredient { Id = 10, Name = "Mozzarella" },
                new Ingredient { Id = 11, Name = "Acciughe" },
                new Ingredient { Id = 12, Name = "Origano" },
                new Ingredient { Id = 13, Name = "Pepe" },
                new Ingredient { Id = 14, Name = "Cipolla" },
                new Ingredient { Id = 15, Name = "Basilico" },
                new Ingredient { Id = 16, Name = "Gorgonzola" },
                new Ingredient { Id = 17, Name = "Rucola" },
                new Ingredient { Id = 18, Name = "Tonno" },
                new Ingredient { Id = 19, Name = "Zucchine" },
                new Ingredient { Id = 20, Name = "Melanzane" },
                new Ingredient { Id = 21, Name = "Spinaci" },
                new Ingredient { Id = 22, Name = "Capperi" },
                new Ingredient { Id = 23, Name = "Olive nere" },
                new Ingredient { Id = 24, Name = "Pancetta" },
                new Ingredient { Id = 25, Name = "Parmigiano" },
                new Ingredient { Id = 26, Name = "Nduja" },
                new Ingredient { Id = 27, Name = "Provolone" },
                new Ingredient { Id = 28, Name = "Grana Padano" },
                new Ingredient { Id = 29, Name = "Feta" },
                new Ingredient { Id = 30, Name = "Bresaola" }

            );

            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Name = "Pizza Margherita",
                   PhotoUrl = "images/Margherita.jpg",
                   Price = 5.00M,
                   DeliveryTime = 10
               },
               new Product
               {
                 Id = 2,
                 Name = "Pizza Prosciutto Cotto",
                 PhotoUrl = "images/PizzaPCotto.jpg",
                 Price = 7.50M,
                 DeliveryTime = 25
               },
               new Product
                   {
                   Id = 3,
                   Name = "Pizza Diavola",
                   PhotoUrl = "images/Diavola.jpg",
                   Price = 8.00M,
                   DeliveryTime = 20
                   },
               new Product
               {
                   Id = 4,
                   Name = "Pizza Quattro Formaggi",
                   PhotoUrl = "images/QuattroFormaggi.jpg",
                   Price = 8.50M,
                   DeliveryTime = 22
               },
               new Product
               {
                   Id = 5,
                   Name = "Pizza Capricciosa",
                   PhotoUrl = "images/Capricciosa.jpg",
                   Price = 9.00M,
                   DeliveryTime = 25
                },
               new Product
               {
                   Id = 6,
                   Name = "Pizza Vegetariana",
                   PhotoUrl = "images/Vegetariana.jpg",
                   Price = 7.00M,
                   DeliveryTime = 20
               },
               new Product
               {
                   Id = 7,
                   Name = "Pizza Tonno e Cipolla",
                   PhotoUrl = "images/TonnoCipolla.jpg",
                   Price = 8.00M,
                   DeliveryTime = 24
               },
               new Product
               {
                    Id = 8,
                    Name = "Pizza Napoletana",
                    PhotoUrl = "images/Napoletana.jpg",
                    Price = 7.50M,
                    DeliveryTime = 22
               },
               new Product
               {
                Id = 9,
                Name = "Pizza Boscaiola",
                PhotoUrl = "images/Boscaiola.jpg",
                Price = 8.50M,
                DeliveryTime = 23
               },
               new Product
               {
                Id = 10,
                Name = "Pizza Calzone",
                PhotoUrl = "images/Calzone.jpg",
                Price = 8.00M,
                DeliveryTime = 20
               },
               new Product
               {
                Id = 11,
                Name = "Pizza Salsiccia e Friarielli",
                PhotoUrl = "images/SalsicciaFriarielli.jpg",
                Price = 9.00M,
                DeliveryTime = 25
               },
               new Product
               {
                Id = 12,
                Name = "Pizza Quattro Stagioni",
                PhotoUrl = "images/QuattroStagioni.jpg",
                Price = 9.50M,
                DeliveryTime = 27
               },
               new Product
               {
                Id = 13,
                Name = "Pizza Ortolana",
                PhotoUrl = "images/Ortolana.jpg",
                Price = 8.00M,
                DeliveryTime = 23
               },
               new Product
               {
                Id = 14,
                Name = "Pizza Marinara",
                PhotoUrl = "images/Marinara.jpg",
                Price = 6.00M,
                DeliveryTime = 20
               },
               new Product
               {
                Id = 15,
                Name = "Pizza Americana",
                PhotoUrl = "images/Americana.jpg",
                Price = 10.00M,
                DeliveryTime = 30
               }

            );

            modelBuilder.Entity<ProductIngredient>().HasData(
                // Pizza Margherita
                new ProductIngredient { ProductId = 1, IngredientId = 10 }, // Mozzarella
                new ProductIngredient { ProductId = 1, IngredientId = 5 },  // Pomodoro
                new ProductIngredient { ProductId = 1, IngredientId = 15 }, // Basilico

                // Pizza Prosciutto Cotto
                new ProductIngredient { ProductId = 2, IngredientId = 10 }, // Mozzarella
                new ProductIngredient { ProductId = 2, IngredientId = 5 },  // Pomodoro
                new ProductIngredient { ProductId = 2, IngredientId = 4 },  // Prosciutto

                // Pizza Diavola
                new ProductIngredient { ProductId = 3, IngredientId = 10 }, // Mozzarella
                new ProductIngredient { ProductId = 3, IngredientId = 9 },  // Peperoni
                new ProductIngredient { ProductId = 3, IngredientId = 5 },  // Pomodoro

                // Pizza Quattro Formaggi
                new ProductIngredient { ProductId = 4, IngredientId = 10 }, // Mozzarella
                new ProductIngredient { ProductId = 4, IngredientId = 16 }, // Gorgonzola
                new ProductIngredient { ProductId = 4, IngredientId = 27 }, // Provolone
                new ProductIngredient { ProductId = 4, IngredientId = 28 }, // Grana Padano

                // Pizza Capricciosa
                new ProductIngredient { ProductId = 5, IngredientId = 10 }, // Mozzarella
                new ProductIngredient { ProductId = 5, IngredientId = 5 },  // Pomodoro
                new ProductIngredient { ProductId = 5, IngredientId = 1 },  // Funghi
                new ProductIngredient { ProductId = 5, IngredientId = 4 },  // Prosciutto
                new ProductIngredient { ProductId = 5, IngredientId = 2 },  // Carciofi
                new ProductIngredient { ProductId = 5, IngredientId = 23 }, // Olive nere

                // Pizza Vegetariana
                new ProductIngredient { ProductId = 6, IngredientId = 10 }, // Mozzarella
                new ProductIngredient { ProductId = 6, IngredientId = 5 },  // Pomodoro
                new ProductIngredient { ProductId = 6, IngredientId = 19 }, // Zucchine
                new ProductIngredient { ProductId = 6, IngredientId = 20 }, // Melanzane
                new ProductIngredient { ProductId = 6, IngredientId = 21 }, // Spinaci

                // Pizza Tonno e Cipolla
                new ProductIngredient { ProductId = 7, IngredientId = 10 }, // Mozzarella
                new ProductIngredient { ProductId = 7, IngredientId = 18 }, // Tonno
                new ProductIngredient { ProductId = 7, IngredientId = 14 }, // Cipolla
                new ProductIngredient { ProductId = 7, IngredientId = 5 },  // Pomodoro

                // Pizza Napoletana
                new ProductIngredient { ProductId = 8, IngredientId = 10 }, // Mozzarella
                new ProductIngredient { ProductId = 8, IngredientId = 11 }, // Acciughe
                new ProductIngredient { ProductId = 8, IngredientId = 22 }, // Capperi
                new ProductIngredient { ProductId = 8, IngredientId = 5 },  // Pomodoro

                // Pizza Boscaiola
                new ProductIngredient { ProductId = 9, IngredientId = 10 }, // Mozzarella
                new ProductIngredient { ProductId = 9, IngredientId = 6 },  // Salsiccia
                new ProductIngredient { ProductId = 9, IngredientId = 1 },  // Funghi
                new ProductIngredient { ProductId = 9, IngredientId = 5 },  // Pomodoro

                // Pizza Calzone
                new ProductIngredient { ProductId = 10, IngredientId = 10 }, // Mozzarella
                new ProductIngredient { ProductId = 10, IngredientId = 4 },  // Prosciutto
                new ProductIngredient { ProductId = 10, IngredientId = 13 }, // Pepe

                // Pizza Salsiccia e Friarielli
                new ProductIngredient { ProductId = 11, IngredientId = 10 }, // Mozzarella
                new ProductIngredient { ProductId = 11, IngredientId = 6 },  // Salsiccia
                new ProductIngredient { ProductId = 11, IngredientId = 21 }, // Friarielli (substitute with Spinaci)

                // Pizza Quattro Stagioni
                new ProductIngredient { ProductId = 12, IngredientId = 10 }, // Mozzarella
                new ProductIngredient { ProductId = 12, IngredientId = 5 },  // Pomodoro
                new ProductIngredient { ProductId = 12, IngredientId = 1 },  // Funghi
                new ProductIngredient { ProductId = 12, IngredientId = 4 },  // Prosciutto
                new ProductIngredient { ProductId = 12, IngredientId = 2 },  // Carciofi

                // Pizza Ortolana
                new ProductIngredient { ProductId = 13, IngredientId = 10 }, // Mozzarella
                new ProductIngredient { ProductId = 13, IngredientId = 19 }, // Zucchine
                new ProductIngredient { ProductId = 13, IngredientId = 20 }, // Melanzane
                new ProductIngredient { ProductId = 13, IngredientId = 5 },  // Pomodoro

                // Pizza Marinara
                new ProductIngredient { ProductId = 14, IngredientId = 5 },  // Pomodoro
                new ProductIngredient { ProductId = 14, IngredientId = 7 },  // Olio d'oliva
                new ProductIngredient { ProductId = 14, IngredientId = 8 },  // Aglio
                new ProductIngredient { ProductId = 14, IngredientId = 12 }, // Origano

                // Pizza Americana
                new ProductIngredient { ProductId = 15, IngredientId = 10 }, // Mozzarella
                new ProductIngredient { ProductId = 15, IngredientId = 9 },  // Peperoni
                new ProductIngredient { ProductId = 15, IngredientId = 24 }, // Pancetta
                new ProductIngredient { ProductId = 15, IngredientId = 5 }   // Pomodoro

            );
        }
    }
}
