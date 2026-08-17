using MyEshop_Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Domain.Entities.Cart
{
	public class Cart
	{
        public int Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public float Price { get; set; }

        public int Userid { get; set; }

        public User User { get; set; }
    }
}
