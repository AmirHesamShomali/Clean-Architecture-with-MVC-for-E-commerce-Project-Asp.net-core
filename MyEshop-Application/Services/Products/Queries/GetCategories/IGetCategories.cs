using MyEshop_Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Products.Queries.GetCategories
{
    public interface IGetCategories
    {
        ResaultCategoriesService GetCategoriesService(int? parentid);
    }

}
