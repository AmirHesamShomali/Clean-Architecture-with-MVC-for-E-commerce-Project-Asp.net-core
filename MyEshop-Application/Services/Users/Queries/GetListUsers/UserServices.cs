using Common;
using MyEshop_Application.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Application.Services.Users.Queries.GetListUsers
{
    public class UserServices : IGetUserServices
    {
        private readonly IDatabaseContext _context;

        public UserServices(IDatabaseContext context)
        {
            _context = context;
        }
        public ResaultUserServices Excute(Request request)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.searchkey))
            {
                users = users.Where(p => p.FullName.Contains(request.searchkey));
            }
            var rowcount = 0;
            var resault= users.ToPaged(request.page, 20, out rowcount).Select(u=>new UserDto()
            {
                Id= u.Id,
                FullName= u.FullName,
                phone= u.phone,
            }).ToList();

            return new ResaultUserServices()
            {
                userDtos = resault,
                Success = true,
                Message = "با موفقیت انجام شد"
            };


        }
    }
}
