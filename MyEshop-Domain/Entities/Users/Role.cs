using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Domain.Entities.Users
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<UserinRole> UserinRoles { get; set; }


    }
}
