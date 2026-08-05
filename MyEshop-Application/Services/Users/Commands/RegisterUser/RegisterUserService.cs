using MyEshop_Application.Interfaces.Contexts;
using MyEshop_Domain.Entities.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyEshop_Application.Services.Users.Commands.RegisterUser;
public class RegisterUserService : IRegisterUserService
{
    private readonly IDatabaseContext _databaseContext;

    public RegisterUserService(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public ResaultRegisterUserServiceDto Execute(RequestRegisterService request)
    {
        try
        {

        if (request.Password != request.Repassword)
        {
            return new ResaultRegisterUserServiceDto()
            {
                Id = 0,
                IsSuccess = false,
                Message = "رمز عبور و تکرار رمز عبور برابر نیست"
            };
        }
        if (_databaseContext.Users.Any(u => u.Email == request.Email))
        {
            return new ResaultRegisterUserServiceDto()
            {
                Id = 0,
                IsSuccess = false,
                Message = "این ایمیل قبلا ثبت شده است."
            };
        }

            var user = new User()
            {
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password,
                UserinRoles = null
        };

        _databaseContext.Users.Add(user);
        _databaseContext.SaveChanges();
        return new ResaultRegisterUserServiceDto()
        {
            Id = user.Id,
            IsSuccess = true,
            Message = "ثبت نام با موفقیت انجام شد"
        };
        }
        catch (Exception ex) {
            return new ResaultRegisterUserServiceDto()
            {
                Id = 0,
                IsSuccess = false,
                Message = "خطای سیستم: " + ex.Message
            };
        }
    }
}
