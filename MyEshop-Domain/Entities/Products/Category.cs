using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Domain.Entities.Products
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public  Category? ParentCategory { get; set; }

        public int? parentcategory_id { get; set; }

        public  ICollection<Category> sub_categories { get; set; }

    }
}
