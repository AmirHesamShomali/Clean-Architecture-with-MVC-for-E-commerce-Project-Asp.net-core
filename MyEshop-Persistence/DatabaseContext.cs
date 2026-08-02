using Microsoft.EntityFrameworkCore;
using MyEshop_Application.Interfaces.Contexts;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
