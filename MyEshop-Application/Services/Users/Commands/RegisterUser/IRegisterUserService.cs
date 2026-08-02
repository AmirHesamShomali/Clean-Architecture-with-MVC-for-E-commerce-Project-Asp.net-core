using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUserService
    {
        ResaultRegisterUserServiceDto Execute(RequestRegisterService request);
    }
}
