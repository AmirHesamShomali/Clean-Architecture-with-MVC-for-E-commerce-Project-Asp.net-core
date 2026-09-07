using Microsoft.AspNetCore.Mvc;
using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Application.Interfaces.IFacedPattern;
using MyEshop_Domain.Entities.Products;

namespace MyEshop_MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProductsController : Controller
    {
        private readonly IDatabaseContext _context;
     
        private readonly IProductFacad _productFacad;

        public ProductsController(IProductFacad productFacad,IDatabaseContext context)
        {
            _productFacad = productFacad;
            _context = context;
        }
        public IActionResult Index()
        {
            var resault = _productFacad.GetListProducts.GetListProductService();
            return View(resault);
        }

        public IActionResult AddProduct()
        {
           
   
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(RequestAddProduct product, IFormFile imagefile)
        {
            var resault =await  _productFacad.Addproduct.AddProductService(product, imagefile);
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            return Redirect ("/admin/products");
        }
        public IActionResult Delete(int product_id)
        {
            var resault=_productFacad.DeleteProducts.DeleteProductService(product_id);
            return Redirect("/admin/products");
        }

        public async Task<IActionResult> Edit(int product_id)
        {
            var resault= await _productFacad.Editproduct.EditProductService(product_id,null,null);

            return View(resault.Product);  
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product, IFormFile imagefile)
        {
            var resault =await _productFacad.Editproduct.EditProductService(product.Id,product,imagefile);

            return Redirect("/admin/products");
        }

        [HttpPost]
        public IActionResult SerchProduct(string SearchString)
        {
            var resault=_productFacad.GetListProductFilter.GetListProductFilterService(SearchString);
            return View("Index",resault);
        }
    }
}
