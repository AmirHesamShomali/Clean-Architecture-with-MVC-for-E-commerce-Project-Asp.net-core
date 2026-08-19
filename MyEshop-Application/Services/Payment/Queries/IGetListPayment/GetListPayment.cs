using MyEshop_Application.Interfaces.Contexts;

namespace MyEshop_Application.Services.Payment.Queries.IGetListPayment
{
    public class GetListPayment : IGetListPayment
    {
        private readonly IDatabaseContext _context;

        public GetListPayment(IDatabaseContext context)
        {
            _context = context;
        }
        public ResaultPaymentService IGetListPaymentService()
        {
            var PaymentList=_context.Payments.ToList();
            return new ResaultPaymentService()
            {
                Success = true,
                Payments = PaymentList
            };
        }
    }
}
