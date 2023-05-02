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
        
        public DbSet<Product> productscatalog { get; set; }
        public DbSet<UserModel> users { get; set; }
        public DbSet<BasketModel> usersbaskets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder conf)
        {
            conf.UseNpgsql("Host=localhost;Port=5432;Database=Products;UserName=postgres;Password=0945;");
        }
    }
}

