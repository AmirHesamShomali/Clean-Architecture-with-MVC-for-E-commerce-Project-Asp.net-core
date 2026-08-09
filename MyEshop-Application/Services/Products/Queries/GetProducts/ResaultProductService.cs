using MyEshop_Domain.Entities.Products;

namespace MyEshop_Application.Services.Products.Queries.GetProducts
{
    public class ResaultProductService
    {
        public List<Product> Products { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
