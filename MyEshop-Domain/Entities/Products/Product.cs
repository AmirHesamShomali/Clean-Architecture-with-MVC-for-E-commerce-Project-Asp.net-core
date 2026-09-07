using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Domain.Entities.Products
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        public int Count { get; set; } = 1;

        public string? ImagePath { get; set; }
    }


    public class RequestAddProduct
        {
        public string Name { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        public string? ImagePath { get; set; }
    }
}
