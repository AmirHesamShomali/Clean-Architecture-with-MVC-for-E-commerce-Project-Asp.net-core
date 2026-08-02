using MyEshop_Application.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Users.Queries.GetListUsers
{
    public interface IGetUserServices
    {
        ResaultUserServices Excute(Request request);
    }

    
}
