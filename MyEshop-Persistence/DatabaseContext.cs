using Microsoft.EntityFrameworkCore;
using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Domain.Entities.Cart;
using MyEshop_Domain.Entities.Comment;
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

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserinRole> UserinRoles { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Cart> Cart { get; set; }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
             .HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 1,
                Name = "هویج",
                Price = 120000,
                Description = "بسیار عالی و درجه یک",
                CategoryId = 1,
                ImagePath = "/asset-page/pics/598b9b14-8dcb-4f3e-886f-367d4b14e51c_product-7.jpg"
            }); ;
            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id=1,
                Name="سبزیجات"
            });
           

            modelBuilder.Entity<Role>().HasData(new Role()
           {
               Id = 1,
               Name = "Admin",
           },new Role
           {
               Id=2,
               Name="Operator" 
           },new Role
           {
               Id=3,
               Name="Customer"
           });
        }
    }
}
