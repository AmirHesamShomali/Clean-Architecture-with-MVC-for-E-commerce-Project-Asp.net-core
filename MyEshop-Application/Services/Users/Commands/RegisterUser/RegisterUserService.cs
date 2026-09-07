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
        if (_databaseContext.Users.Any(u => u.phone == request.phone))
        {
            return new ResaultRegisterUserServiceDto()
            {
                Id = 0,
                IsSuccess = false,
                Message = "این شماره تلفن قبلا ثبت شده است."
            };
        }

            var user = new User()
            {
                FullName = request.FullName,
                phone =request.phone ,
                Password = request.Password,
                IsAdmin = request.IsAdmin,
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
