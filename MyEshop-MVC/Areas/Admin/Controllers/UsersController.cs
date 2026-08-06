using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using MyEshop_Application.Services.Users.Commands.DeleteUsers;
using MyEshop_Application.Services.Users.Commands.EditUser;
using MyEshop_Application.Services.Users.Commands.RegisterUser;
using MyEshop_Application.Services.Users.Queries.GetListUsers;
using MyEshop_Application.Services.Users.Queries.GetRoles;

namespace EndPointStore.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IEditUserService _editUserService;

        private readonly IGetUserServices _userServices;

        private readonly IDeleteUserService _deleteUserService;

        private readonly IRegisterUserService _registerUser;

        public UsersController(IGetUserServices userServices, IRegisterUserService registerUser, IDeleteUserService deleteUserService, IEditUserService editUserService)
        {
            _userServices = userServices;
            _registerUser = registerUser;
            _deleteUserService = deleteUserService;
            _editUserService = editUserService;
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

            return View();
        }
        [HttpPost]
        public IActionResult Create(RequestRegisterService requestRegister)
        {
            if (!ModelState.IsValid)
            {
                return View(requestRegister);
            }
            var resault = _registerUser.Execute(requestRegister);
            if (!resault.IsSuccess)
            {
                ViewBag.Message=resault.Message;
                return View();
            }

            return RedirectToAction("Index");
        }
            public IActionResult Delete(int userid)
            {
                var resault=_deleteUserService.DeleteService(userid);
                if(!resault.Success)
                {
                    ViewData["Message"]=resault.Message;
                    return View("Index");
                }
                return RedirectToAction("Index");
            }
        public IActionResult Edit(int userid)
        {
            var resault = _editUserService.EditUser(userid);

            return View(resault);
        }
        [HttpPost]
        public IActionResult Edit(ResaultEditUserService resaultEdit)
        {
            var newresault = _editUserService.EditUser(resaultEdit.user.Id,resaultEdit);

            return RedirectToAction("Index");
        }
    }
}
