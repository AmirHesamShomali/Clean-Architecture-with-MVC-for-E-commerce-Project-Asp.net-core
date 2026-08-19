using Microsoft.AspNetCore.Mvc;
using MyEshop_Application.Services.Payment.Queries.IGetListPayment;

namespace MyEshop_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentController : Controller
    {
        private readonly IGetListPayment _getListPayment;

        public PaymentController(IGetListPayment getListPayment)
        {
            _getListPayment = getListPayment;
        }
        public IActionResult Index()
        {
            var resault = _getListPayment.IGetListPaymentService();
            return View(resault.Payments);
        }
    }
}
