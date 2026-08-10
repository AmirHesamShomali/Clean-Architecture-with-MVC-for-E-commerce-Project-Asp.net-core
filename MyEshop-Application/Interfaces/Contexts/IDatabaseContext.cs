using Microsoft.EntityFrameworkCore;
using MyEshop_Domain.Entities.Comment;
using MyEshop_Domain.Entities.Products;
using MyEshop_Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Interfaces.Contexts
{
    public interface IDatabaseContext
    {
         DbSet<User> Users { get; set; }

         DbSet<Role> Roles { get; set; }

         DbSet<UserinRole> UserinRoles { get; set; }

         DbSet<Category> Category { get; set; }

         DbSet<Product> Products { get; set; }
        DbSet<Comment> Comments { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken=new CancellationToken());


    }
}
