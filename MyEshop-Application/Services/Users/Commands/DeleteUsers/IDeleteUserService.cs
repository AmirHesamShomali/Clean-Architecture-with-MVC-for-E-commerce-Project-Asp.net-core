using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Users.Commands.DeleteUsers
{
    public interface IDeleteUserService
    {
        ResaultDeleteUserServiceDto DeleteService(int userId);
    }
}
