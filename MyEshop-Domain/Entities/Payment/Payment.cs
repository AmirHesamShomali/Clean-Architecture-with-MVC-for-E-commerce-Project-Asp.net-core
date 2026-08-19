using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Domain.Entities.Payment
{
    public class Payment
    {
        public int Id { get; set; }

        public String UserName { get; set; }

        public DateTime TimeSubmit { get; set; }

        public string  TotalPrice { get; set; }

        public bool Success { get; set; }
    }
}
