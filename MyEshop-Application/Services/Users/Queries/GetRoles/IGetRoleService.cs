using MyEshop_Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyEshop_Application.Services.Users.Queries.GetRoles.GetRoleService;

namespace MyEshop_Application.Services.Users.Queries.GetRoles
{
    public interface IGetRoleService
    {
        List<RolesDto> GetRoles();
    }
}
