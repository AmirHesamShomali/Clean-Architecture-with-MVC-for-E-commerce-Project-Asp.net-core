using Microsoft.EntityFrameworkCore;
using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Domain.Entities.Cart;
using MyEshop_Domain.Entities.Comment;
using MyEshop_Domain.Entities.Order;
using MyEshop_Domain.Entities.Payment;
using MyEshop_Domain.Entities.Products;
using MyEshop_Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Persistence
{
    public class DatabaseContext:DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Cart> Cart { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 1,
                Name = "هویج",
                Price = 120000,
                Description = "بسیار عالی و درجه یک",
                ImagePath = "/asset-page/pics/0b017d36-e733-4802-b5c7-43371a71545a_product-7.jpg"
            }); ;
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FullName="امیر حسام شمالی",
                phone="09371890432",
                IsAdmin=true,
                Password="123",

            });
        }
    }
}
