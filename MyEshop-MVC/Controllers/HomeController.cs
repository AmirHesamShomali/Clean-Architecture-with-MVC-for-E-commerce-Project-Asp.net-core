using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Domain.Entities.Order;
using MyEshop_MVC.Models;
using Services.Orders.Command.AddOrder;
using System.Diagnostics;

namespace MyEshop_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IDatabaseContext _databaseContext;

        private readonly IAddOrder _addOrder;
        public HomeController(ILogger<HomeController> logger, IDatabaseContext databaseContext, IAddOrder addOrder)
        {
            _logger = logger;
            _databaseContext = databaseContext;
            _addOrder = addOrder;
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
        [Authorize]
        public IActionResult Privacy()
        {
            var model = new RequestOrder();
            model.User_Name = User.Identity.Name;
            model.Phone = User.FindFirst(System.Security.Claims.ClaimTypes.MobilePhone)?.Value;

            return View(model);
        }


        [HttpPost]
        [Authorize]

        public async Task<IActionResult> Privacy(RequestOrder order,IFormFile imagefile)
        {
            var resault=await _addOrder.addOrderservice(order, imagefile);
            
            return View("Success");
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
