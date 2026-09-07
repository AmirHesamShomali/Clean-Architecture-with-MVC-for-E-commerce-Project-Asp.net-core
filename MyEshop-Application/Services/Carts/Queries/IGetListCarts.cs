using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Domain.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyEshop_Application.Services.Carts.Queries.GetListCarts;

namespace MyEshop_Application.Services.Carts.Queries
{
    public interface IGetListCarts
    {
		ResaultListCart GetListService(string phone);
    }

    public class GetListCarts : IGetListCarts
    {
        private readonly IDatabaseContext _context;

        public GetListCarts(IDatabaseContext context)
        {
            _context = context;
        }
        public ResaultListCart GetListService(string phone)
        {
            var user=_context.Users.FirstOrDefault(u=>u.phone== phone);
			var Carts = _context.Cart.Where(u => u.Userid == user.Id).ToList();
            var sumofprice=_context.Cart.Where(u=>u.Userid==user.Id).Sum(c=>c.Price);
			return new ResaultListCart()
            {
                Carts = Carts,
                SumOfPrice = sumofprice
            };
        }


        public class ResaultListCart
        {
            public List<Cart> Carts { get; set; }

            public float SumOfPrice { get; set; }
        }
    }
}
