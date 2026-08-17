using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEshop_Application.Services.Carts.Command;
using MyEshop_Application.Services.Carts.Queries;
using MyEshop_Domain.Entities.Products;
using Services.Carts.Command;

namespace MyEshop_MVC.Controllers
{
	public class CartController : Controller
	{
        private readonly IRemoveCart _RemoveCart;
        private readonly IAddCart _AddCart;

        private readonly IGetListCarts _GetListCarts;
        public CartController(IAddCart AddCart, IGetListCarts GetListCarts, IRemoveCart RemoveCart)
        {
            _AddCart = AddCart;
            _GetListCarts = GetListCarts;
            _RemoveCart = RemoveCart;
        }
        [Authorize]
        public IActionResult Index()
        {
            var email = User.Identity.Name;
            var result = _GetListCarts.GetListService(email);
            ViewBag.SumOfPrice = result.SumOfPrice;
            return View(result.Carts);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddToCart(int product_id, int quantity, string Emailuser)
        {
            _AddCart.AddCartService(product_id, quantity, Emailuser);
            return RedirectToAction("Index");
        }

        [HttpPost, Authorize]
        public IActionResult RemoveFromCart(int cat_id)
        {
            _RemoveCart.DeleteCartService(cat_id);
            return RedirectToAction("Index");
        }
    }
}
