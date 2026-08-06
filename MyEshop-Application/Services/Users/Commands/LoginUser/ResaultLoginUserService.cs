using MyEshop_Domain.Entities.Users;

namespace Services.Users.Commands.LoginUser
{
    public class ResaultLoginUserService
    {

        public User user { get; set; }
        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
