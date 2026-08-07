using Microsoft.AspNetCore.Mvc;
using MyEshop_Application.Interfaces.IFacedPattern;
using MyEshop_Application.Services.Products.Command.Addnewcategory;

namespace MyEshop_MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoriesController : Controller
    {
        private readonly IProductFacad _productFacad;

        public CategoriesController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(int? parentid)
        {
            var categories = _productFacad.GetCategories.GetCategoriesService(parentid);
            return View(categories);
        }

        [HttpGet]
        public IActionResult AddNewCategory(int? parentid)
        {
            ViewBag.Parentid = parentid;    
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(RequestCategories requestCategories)
        {
            var resault=_productFacad.Addcategory.Execute(requestCategories.parentid,requestCategories.Name);
            return Redirect("/admin/categories/index");
        }

    }
}
