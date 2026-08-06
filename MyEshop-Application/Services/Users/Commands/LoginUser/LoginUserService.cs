using MyEshop_Application.Interfaces.Contexts;

namespace Services.Users.Commands.LoginUser
{
    public class LoginUserService : ILoginUserService
    {
        private readonly IDatabaseContext _databaseContext;
        public LoginUserService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public ResaultLoginUserService GetUserLogin(string Email,string Password)
        {
            var user = _databaseContext.Users.FirstOrDefault(u => u.Email == Email&&u.Password==Password);
            if (user == null)
            {
                return new ResaultLoginUserService()
                {
                    Success = false,
                    Message = "در سایت ما ثبت نام نکردید"
                };
            }
            return new ResaultLoginUserService()
            {
                user = user,
                Success = true,
                Message = "کاربر وجود دارد"
            };
        }
    }
}
