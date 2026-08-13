using Microsoft.AspNetCore.Mvc;
using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Application.Interfaces.IFacedPattern;
using MyEshop_Application.Services.Products.Queries.GetCategories;
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
           
            ViewBag.Categories = _context.Category.Where(p => p.parentcategory_id == null).ToList();
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(RequestAddProduct product, IFormFile imagefile)
        {
            var resault =await  _productFacad.Addproduct.AddProductService(product, imagefile);
            if (!ModelState.IsValid)
            {

                ViewBag.Categories = _context.Category.Where(p => p.parentcategory_id == null).ToList();
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
    }
}
