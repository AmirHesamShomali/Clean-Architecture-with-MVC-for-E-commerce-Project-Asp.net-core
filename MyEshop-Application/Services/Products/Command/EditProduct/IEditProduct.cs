using Microsoft.AspNetCore.Http;
using MyEshop_Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Products.Command.EditProduct
{
    public interface IEditProduct
    {
        Task<ResaultEditProduct> EditProductService(int product_id,Product? product=null ,IFormFile? imagefile=null);
    }
}
