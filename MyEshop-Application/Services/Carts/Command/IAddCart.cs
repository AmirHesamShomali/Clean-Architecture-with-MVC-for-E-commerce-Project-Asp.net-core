using MyEshop_Domain.Entities.Products;
using MyEshop_Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Carts.Command.AddCart;
namespace Services.Carts.Command
{
    public interface IAddCart
    {
        ResaultCart AddCartService(int product_id,int quantity, string phone);

    }
}
