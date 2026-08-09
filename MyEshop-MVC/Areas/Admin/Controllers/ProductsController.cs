using Microsoft.AspNetCore.Mvc;
using MyEshop_Application.Interfaces.IFacedPattern;

namespace MyEshop_MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;

        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index()
        {
            var resault = _productFacad.GetListProducts.GetListProductService();
            return View(resault);
        }


        public IActionResult Delete(int product_id)
        {
            var resault=_productFacad.DeleteProducts.DeleteProductService(product_id);
            return Redirect("/admin/products");
        }
    }
}
