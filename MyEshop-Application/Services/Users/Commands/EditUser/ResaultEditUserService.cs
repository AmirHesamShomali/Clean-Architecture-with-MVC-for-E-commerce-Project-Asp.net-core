using MyEshop_Domain.Entities.Users;

namespace MyEshop_Application.Services.Users.Commands.EditUser
{
    public class ResaultEditUserService
    {
        public User user { get; set; }
        public bool Suceess { get; set; }

        public string Message { get; set; }

    }
}