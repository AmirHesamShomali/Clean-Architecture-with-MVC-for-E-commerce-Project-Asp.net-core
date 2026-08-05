using MyEshop_Application.Interfaces.Contexts;

namespace MyEshop_Application.Services.Users.Commands.DeleteUsers
{
    public class DeleteUserService : IDeleteUserService
    {
        private readonly IDatabaseContext _context;

        public DeleteUserService(IDatabaseContext context)
        {
            _context = context;   
        }
        public ResaultDeleteUserServiceDto DeleteService(int userId)
        {
            var user = _context.Users.FirstOrDefault(u=>u.Id==userId);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return new ResaultDeleteUserServiceDto()
            {
                Success = true,
                Message = "حذف با موفقیت انجام شد"
            };
        }
    }
}
