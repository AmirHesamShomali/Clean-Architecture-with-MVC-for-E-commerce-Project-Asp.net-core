using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Users.Commands.EditUser
{
    public interface IEditUserService
    {
        ResaultEditUserService EditUser(int user_id, ResaultEditUserService resaultEdit = null);
    }
}