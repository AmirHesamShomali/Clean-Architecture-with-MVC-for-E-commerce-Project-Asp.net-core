using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Domain.Entities.Cart;
using MyEshop_Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Orders.Command.AddProducttoCart
{
    public interface IAddProducttoCart
    {
        ResaultAddProducttoCart AddProducttoCartService(RequestAddProducttoCart request, string phonenumber);
    }


    public class AddProducttoCart : IAddProducttoCart
    {
        private readonly IDatabaseContext _context;
        public AddProducttoCart(IDatabaseContext context)
        {
             _context = context;
        }
        public ResaultAddProducttoCart AddProducttoCartService(RequestAddProducttoCart request, string phonenumber)
        {
            var user=_context.Users.FirstOrDefault(u=>u.phone==phonenumber);
            var newcart = new Cart();
            newcart.Name = request.Name;
            newcart.Price=request.Price;
            newcart.Count=request.Count;
            newcart.Userid=user.Id;
            _context.Cart.Add(newcart);
            _context.SaveChanges();
            return new ResaultAddProducttoCart()
            {
                Success = true,
                Message = "عملیات با موفقیت انجام شد."
            };

        }
    }

    public class RequestAddProducttoCart()
    {
        public string Name { get; set; }

        public int Count { get; set; }

        public float Price { get; set; }

        public int Userid { get; set; }
    }

    public class ResaultAddProducttoCart()
    {
        public bool  Success { get; set; }

        public string Message { get; set; }
    }
}
