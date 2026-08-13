using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Domain.Entities.Products;

namespace MyEshop_Application.Services.Products.Command.EditProduct
{
    public class EditProduct : IEditProduct
    {

        private readonly IDatabaseContext _context;

        private readonly IWebHostEnvironment _environment;
        public EditProduct(IDatabaseContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<ResaultEditProduct> EditProductService(int product_id, Product? product = null, IFormFile? imagefile = null)
        {
            if(imagefile==null&&product==null)
            {
            var productexit = _context.Products.FirstOrDefault(p=>p.Id== product_id);

            return new ResaultEditProduct()
            {
                Product = productexit,
                Success = true,
                Message = "عملیات با موفقیت انجام شد"
            };

            }else
            {
                var productexit = _context.Products.FirstOrDefault(p => p.Id ==product_id);
                _context.Products.Remove(productexit);
                var newproduct = new Product()
                {
                    Id = product_id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    ImagePath = await SaveFileAsync(imagefile),
                    CategoryId = product.CategoryId,
                };
                _context.Products.Add(newproduct);
                 _context.SaveChanges(); 
                 async Task<string> SaveFileAsync(IFormFile file)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "asset-page", "pics");
                    if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    return "/asset-page/pics/" + uniqueFileName;
                }
                return new ResaultEditProduct()
                {
                    Message = "عملیات با موفقیت انجام شد",
                    Success = true,
                    Product = newproduct,
                };
            }
        }
    }
}
