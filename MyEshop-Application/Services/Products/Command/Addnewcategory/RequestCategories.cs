using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Products.Command.Addnewcategory
{
    public class RequestCategories
    {
        public int? parentid { get; set; }
        [Required(ErrorMessage ="این فیلد را پر کنید..")]
        public string Name { get; set; }
    }
}
