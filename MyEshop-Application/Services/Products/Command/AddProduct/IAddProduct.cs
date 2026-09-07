using Microsoft.AspNetCore.Hosting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using Image = SixLabors.ImageSharp.Image;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyEshop_Application.Services.Products.Command.AddProduct
{
    public interface IAddProduct
    {
        Task<Product> AddProductService(RequestAddProduct product, IFormFile imageFile);
    }

    public class AddProduct : IAddProduct
    {
        private readonly IDatabaseContext _context;
        private readonly IWebHostEnvironment _environment;
        public AddProduct(IDatabaseContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }
        public async Task<Product> AddProductService(RequestAddProduct product, IFormFile imageFile)
        {
            var NewProduct = new Product();
            NewProduct.Name = product.Name;
            NewProduct.Description = product.Description;
            NewProduct.Price = product.Price;
            NewProduct.ImagePath = await SaveFileAsync(imageFile);
            _context.Products.Add(NewProduct);
            await _context.SaveChangesAsync();
            return NewProduct;
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            string uploadsFolder = Path.Combine(_environment.WebRootPath, "asset-page", "pics");
            if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var image = await SixLabors.ImageSharp.Image.LoadAsync(file.OpenReadStream()))
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
    




}
