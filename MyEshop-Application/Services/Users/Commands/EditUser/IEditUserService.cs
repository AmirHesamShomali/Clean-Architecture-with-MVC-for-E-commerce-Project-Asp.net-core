using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Domain.Entities.Users;
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

    public class EditUserService : IEditUserService
    {
        private readonly IDatabaseContext _databaseContext;

        public EditUserService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public ResaultEditUserService EditUser(int user_id, ResaultEditUserService resaultEdit = null)
        {
            if (resaultEdit != null)
            {
                var user = _databaseContext.Users.FirstOrDefault(u => u.Id == user_id);

                _databaseContext.Users.Remove(user);

                var NewUser = new User();
                NewUser.Id = user_id;
                NewUser.FullName = resaultEdit.user.FullName;
                NewUser.Email = resaultEdit.user.Email;
                NewUser.Password = resaultEdit.user.Password;
                _databaseContext.Users.Add(NewUser);
                _databaseContext.SaveChanges(); 
                return new ResaultEditUserService()
                {
                    user = NewUser,
                    Suceess = true,
                    Message = "عملیات با موفقیت انجام شد"
                };

            }
            else
            {
                var user = _databaseContext.Users.FirstOrDefault(u => u.Id == user_id);
                return new ResaultEditUserService()
                {
                    user = user,
                    Suceess = true,
                    Message = "عملیات با موفقیت انجام شد"
                };

            }




        }
    }
}