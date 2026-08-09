using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Products.Command.AddProducts
{
    public interface IDeleteProducts
    {
        ResaultDeleteProduct DeleteProductService(int product_id);
    }
}
