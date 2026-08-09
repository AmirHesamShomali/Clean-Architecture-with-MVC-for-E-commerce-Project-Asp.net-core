using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Products.Queries.GetProducts
{
    public interface IGetListProducts
    {
        ResaultProductService GetListProductService();
    }
}
