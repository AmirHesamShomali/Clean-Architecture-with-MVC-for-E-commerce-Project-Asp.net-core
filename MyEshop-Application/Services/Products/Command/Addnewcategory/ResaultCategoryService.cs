using MyEshop_Domain.Entities.Products;

namespace MyEshop_Application.Services.Products.Command.Addnewcategory
{
    public class ResaultCategoryService
    {
        public Category category { get; set; }
        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
