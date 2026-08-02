using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Application.Services.Users.Commands.RegisterUser;
using MyEshop_Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Users.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDatabaseContext _databaseContext;

        public RegisterUserService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public ResaultRegisterUserServiceDto Execute(RequestRegisterService request)
        {
            var user = new User();
            user.FullName=request.FullName;
            user.Email=request.Email;
            var userinroles = new List<UserinRole>();
            foreach(var i in request.roles)
            {
                var role = _databaseContext.Roles.Find(i.Id);
                userinroles.Add(new UserinRole()
                {
                    Role = role,
                    role_id = role.Id,
                    User = user,
                    user_id = user.Id

                });
                user.UserinRoles = userinroles;
            }

            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();
            return new ResaultRegisterUserServiceDto()
            {
                Id=user.Id,
                IsSuccess=true,
                Message="ثبت نام با موفقیت انجام شد"
            };
        }
        
    }
}
