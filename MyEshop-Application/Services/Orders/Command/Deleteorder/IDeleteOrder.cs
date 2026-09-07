using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MyEshop_Application.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Orders.Command.Deleteorder
{
    public interface IDeleteOrder
    {
        void DeleteOrderservice(int order_id);
    }
    public class DeleteOrder : IDeleteOrder
    {
        private readonly IDatabaseContext _context;
        private readonly IWebHostEnvironment _environment;

        public DeleteOrder(IDatabaseContext context,IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = context;
        }
        public void DeleteOrderservice(int order_id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == order_id);

            if (order != null)
            {
                if (!string.IsNullOrEmpty(order.ImagePath)) 
                {
                    string relativePath = order.ImagePath.TrimStart('/');
                    string fullPath = Path.Combine(_environment.WebRootPath, relativePath);
                    if (System.IO.File.Exists(fullPath))
                    {
                        try
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
        public bool DeleteFile(string filePathFromDb)
        {
            string relativePath = filePathFromDb.TrimStart('/');
            string fullPath = Path.Combine(_environment.WebRootPath, relativePath);
            if (System.IO.File.Exists(fullPath))
            {
                try
                {
                    System.IO.File.Delete(fullPath);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return false;
        }
    }
}
