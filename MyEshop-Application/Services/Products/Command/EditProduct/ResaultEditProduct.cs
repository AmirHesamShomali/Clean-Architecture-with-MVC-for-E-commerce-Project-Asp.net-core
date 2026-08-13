using MyEshop_Domain.Entities.Products;

namespace MyEshop_Application.Services.Products.Command.EditProduct
{
    public class ResaultEditProduct
    {
        public Product Product { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
