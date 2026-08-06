using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users.Commands.LoginUser
{
    public interface ILoginUserService
    {
        ResaultLoginUserService GetUserLogin(string Email, string Password);
    }
}
