using Microsoft.AspNetCore.Mvc;
using MyEshop_Application.Services.Orders.Command.AddProducttoCart;
using MyEshop_Application.Services.Orders.Command.Deleteorder;
using MyEshop_Application.Services.Orders.Queries.IGetListOrder;

namespace MyEshop_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IAddProducttoCart _addProducttoCart;
        private readonly IDeleteOrder _deleteOrder;
        private readonly IGetListOrders _getListOrders;
        public OrderController(IGetListOrders getListOrders, IDeleteOrder deleteOrder, IAddProducttoCart addProducttoCart)
        {
            _addProducttoCart = addProducttoCart;
            _getListOrders = getListOrders;
            _deleteOrder = deleteOrder;
        }
        public IActionResult Index()
        {
            var orders = _getListOrders.GetListorderservice();
            return View(orders);
        }


        public IActionResult Deletorder(int order_id)
        {
            _deleteOrder.DeleteOrderservice(order_id);
            return RedirectToAction("Index");
        }

        public IActionResult AddProducttoCart(string phone_number)
        {
            var phone_user = phone_number;
            ViewBag.phone_number = phone_number;    
            return View();
        }
        [HttpPost]
        public IActionResult AddProducttoCart(RequestAddProducttoCart request,string phonenumber)
        {
            _addProducttoCart.AddProducttoCartService(request,phonenumber);
            return Redirect("/admin/order");
        }
    }
}
