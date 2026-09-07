using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using Microsoft.Extensions.Hosting;
using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Domain.Entities.Order;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Domain.Entities.Products;

namespace Services.Orders.Command.AddOrder
{
    public interface IAddOrder
    {
        Task<ResaultAddOrder> addOrderservice(RequestOrder order, IFormFile imageFile);
    }

    public class AddOrder : IAddOrder
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly IWebHostEnvironment _environment;

        public AddOrder(IDatabaseContext databaseContext, IWebHostEnvironment environment)
        {
            _databaseContext = databaseContext;
            _environment = environment;
        }
        public async Task<ResaultAddOrder> addOrderservice(RequestOrder order, IFormFile imageFile)
        {
            var NewOrder = new Order();
            NewOrder.User_Name = order.User_Name;
            NewOrder.Product_Name = order.Product_Name;
            NewOrder.Phone = order.Phone;
            NewOrder.ImagePath = await SaveFileAsync(imageFile);
            _databaseContext.Orders.Add(NewOrder);
            await _databaseContext.SaveChangesAsync();
            return new ResaultAddOrder()
            {
                Success = true,
                Name = "عملیات با موفقیت انجام شد."
            };
        }
        public async Task<string> SaveFileAsync(IFormFile file)
        {
            string uploadsFolder = Path.Combine(_environment.WebRootPath, "asset-page", "pics");
            if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var image = await Image.LoadAsync(file.OpenReadStream()))
            {
                int width = image.Width;
                int height = image.Height;
                if (width > 1200)
                {
                    image.Mutate(x => x.Resize(1200, 0));
                }

                var encoder = new JpegEncoder { Quality = 75 };

                await image.SaveAsync(filePath, encoder);
            }

            return "/asset-page/pics/" + uniqueFileName;
        }
    }

    public class ResaultAddOrder
    {
        public bool Success { get; set; }

        public string Name { get; set; }
    }
}
