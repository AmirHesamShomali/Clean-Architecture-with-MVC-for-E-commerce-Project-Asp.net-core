using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyEshop_Application.Interfaces.Contexts;
using MyEshop_MVC.Models;
using System.Diagnostics;

namespace MyEshop_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IDatabaseContext _databaseContext;

        public HomeController(ILogger<HomeController> logger, IDatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            var products = _databaseContext.Products.Select(p => new ProductViewModel()
            {
                Id = p.Id,
                PathImage = p.ImagePath,
                Name = p.Name,
                Price = p.Price,
            }).ToList();

            ViewBag.Comments=_databaseContext.Comments.ToList();
            return View(products);
        }

        public IActionResult Privacy()
        {
            
            return View();
        }


        public IActionResult Ditails(int productid)
        {
            var product = _databaseContext.Products.FirstOrDefault(p=>p.Id==productid);
            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
