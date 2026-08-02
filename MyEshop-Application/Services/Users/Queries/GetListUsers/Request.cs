using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Users.Queries.GetListUsers
{
    public class Request
    {
        public string searchkey { get; set; }

        public int page { get; set; } = 1;
    }
}
