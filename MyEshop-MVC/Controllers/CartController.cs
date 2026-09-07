using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEshop_Application.Services.Carts.Command;
using MyEshop_Application.Services.Carts.Queries;
using MyEshop_Application.Services.pay.Command;
using MyEshop_Domain.Entities.Cart;
using MyEshop_Domain.Entities.Products;
using Services.Carts.Command;
using System.Security.Claims;

namespace MyEshop_MVC.Controllers
{
	public class CartController : Controller
	{
        private readonly IRemoveCart _RemoveCart;
        private readonly IAddCart _AddCart;
        private readonly IAddPayment _Addpayment;

        private readonly IGetListCarts _GetListCarts;
        public CartController(IAddCart AddCart, IGetListCarts GetListCarts, IRemoveCart RemoveCart, IAddPayment Addpayment)
        {
            _AddCart = AddCart;
            _GetListCarts = GetListCarts;
            _Addpayment = Addpayment;
            _RemoveCart = RemoveCart;
        }
        [Authorize]
        public IActionResult Index()
        {
            var phoneClaim = User.FindFirst(ClaimTypes.MobilePhone);
            string phone = phoneClaim?.Value;
            var result = _GetListCarts.GetListService(phone);
            ViewBag.SumOfPrice = result.SumOfPrice;
            return View(result.Carts);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddToCart(int product_id, int quantity, string phone)
        {
            _AddCart.AddCartService(product_id, quantity, phone);
            return RedirectToAction("Index");
        }

        [HttpPost, Authorize]
        public IActionResult RemoveFromCart(int cat_id)
        {
            _RemoveCart.DeleteCartService(cat_id);
            return RedirectToAction("Index");
        }

        [HttpPost, Authorize]
        public IActionResult Payment(string username, string SumOfPrice, string address)
        {
            var resault=_Addpayment.AddPaymentService(username, SumOfPrice,address);

            return View("Success");
        }
    }
}
