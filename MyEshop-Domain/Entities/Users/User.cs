using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Domain.Entities.Users
{
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string phone { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}
