using MyEshop_Application.Services.Products.Command.Addnewcategory;
using MyEshop_Application.Services.Products.Command.AddProducts;
using MyEshop_Application.Services.Products.Queries.GetCategories;
using MyEshop_Application.Services.Products.Queries.GetProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Interfaces.IFacedPattern
{
    public interface IProductFacad
    {
        Addcategory Addcategory { get;}

        GetCategories GetCategories {  get;}

        GetListProducts GetListProducts { get;}

        DeleteProducts DeleteProducts { get;}   


    }
}
