using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Domain.Entities.Users
{
    public class UserinRole
    {
        public int Id { get; set; }

        public User User { get; set; }
        public int user_id { get; set; }

        public Role Role { get; set; }
        public int role_id { get; set; }
    }
}
