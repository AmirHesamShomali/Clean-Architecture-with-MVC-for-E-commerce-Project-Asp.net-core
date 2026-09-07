using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Domain.Entities.Order
{
    public class Order
    {
        public int Id { get; set; }

        public string User_Name { get; set; }

        public string Phone { get; set; }
        [Required]

        public string Product_Name { get; set; }

        public string? ImagePath { get; set; }
    }
    public class RequestOrder
    {
        public string User_Name { get; set; }

        public string Phone { get; set; }
        [Required]

        public string Product_Name { get; set; }
    }
}
