using MyEshop_Application.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Carts.Command
{
    public interface IRemoveCart
    {
        bool DeleteCartService(int cat_id);
    }

    public class RemoveCart : IRemoveCart
    {
        private readonly IDatabaseContext _context;

        public RemoveCart(IDatabaseContext context)
        {
            _context = context;
        }
        public bool DeleteCartService(int cat_id)
        {
            var cartitem = _context.Cart.FirstOrDefault(c=>c.Id==cat_id);
            _context.Cart.Remove(cartitem);
            _context.SaveChanges();
            return true;
        }
    }
}
