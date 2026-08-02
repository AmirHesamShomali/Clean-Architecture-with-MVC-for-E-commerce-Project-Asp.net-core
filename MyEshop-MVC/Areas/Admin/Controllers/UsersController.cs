using Microsoft.AspNetCore.Mvc;
using MyEshop_Application.Services.Users.Queries.GetListUsers;
using MyEshop_Application.Services.Users.Queries.GetRoles;

namespace EndPointStore.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUserServices _userServices;

        private readonly IGetRoleService _roleServices;

        public UsersController(IGetUserServices userServices, IGetRoleService roleServices)
        {
            _userServices = userServices;
            _roleServices = roleServices;
        }
        public IActionResult Index(string searchkey, int page = 1)
        {
            var users = _userServices.Excute(new Request()
            {
                searchkey = searchkey,
                page = page
            });
            return View(users);
        }

        public IActionResult Create()
        {
            var roles=_roleServices.GetRoles();

            return View(roles);
        }
    }
}
