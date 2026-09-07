using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Domain.Entities.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.pay.Command
{
    public interface IAddPayment
    {
        bool AddPaymentService(string UserName, string TotalPrice , string address);
    }

    public class AddPayment : IAddPayment
    {
        private readonly IDatabaseContext _context;

        public AddPayment(IDatabaseContext  context)
        {
            _context = context;
        }
        public bool AddPaymentService(string UserName,string TotalPrice, string address)
        {
            var NewPayment = new MyEshop_Domain.Entities.Payment.Payment
            {
                address=address,
                UserName = UserName,
                TotalPrice=TotalPrice,
                TimeSubmit = DateTime.Now,
                Success = true
            };
            _context.Payments.Add(NewPayment);
            _context.SaveChanges();
            return true;
        }
    }

}
