using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Products.Command.Addnewcategory
{
    public interface IAddcategory
    {
        ResaultCategoryService Execute(int? Parentid,string Name);
    }
}
