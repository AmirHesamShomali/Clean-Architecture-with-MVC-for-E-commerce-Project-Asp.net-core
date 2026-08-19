namespace MyEshop_Application.Services.Payment.Queries.IGetListPayment
{
    public class ResaultPaymentService
    {

        public  List<MyEshop_Domain.Entities.Payment.Payment> Payments { get; set; }
        public bool Success { get; set; }

        
    }
}
