using System;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using EfLesson.Models;
using Microsoft.Extensions.Options;

namespace EfLesson.DAL
{
    public class ProductDb : DbContext
    {
        public ProductDb()
        {
            Database.EnsureCreated();
            Database.EnsureCreated();
        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<BasketModel> UsersBaskets { get; set; }
        public DbSet<OrderModel> UserOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder conf)
        {
            conf.UseNpgsql("Host=localhost;Port=5432;Database=Products;UserName=postgres;Password=0945;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductsFromBasket>()
                        .HasKey(bc => new { bc.BasketId, bc.ProductId });

            modelBuilder.Entity<ProductsFromOrder>()
                        .HasKey(bc => new { bc.OrderId, bc.ProductId });

            modelBuilder.Entity<ProductsFromBasket>()
                        .HasOne<ProductModel>(p => p.Product)
                        .WithMany(b => b.ProductsFromBaskets)
                        .HasForeignKey(id => id.ProductId);
            modelBuilder.Entity<ProductsFromBasket>()
                        .HasOne<BasketModel>(p => p.Basket)
                        .WithMany(pfb => pfb.ProductsFromBaskets)
                        .HasForeignKey(id => id.BasketId);

            modelBuilder.Entity<ProductsFromOrder>()
                        .HasOne<ProductModel>(p => p.Product)
                        .WithMany(pfo => pfo.ProductsFromOrders)
                        .HasForeignKey(id => id.ProductId);
            modelBuilder.Entity<ProductsFromOrder>()
                        .HasOne<OrderModel>(o => o.Order)
                        .WithMany(pfo => pfo.ProductsFromOrders)
                        .HasForeignKey(id => id.OrderId);

            modelBuilder.Entity<UserModel>()
                        .HasOne<BasketModel>(b => b.Basket)
                        .WithOne(u => u.User)
                        .HasForeignKey<BasketModel>(id => id.UserId);

            modelBuilder.Entity<UserModel>()
                        .HasMany<OrderModel>(o => o.Orders)
                        .WithOne(u => u.User)
                        .HasForeignKey(id => id.UserId);
        }
    }
}
