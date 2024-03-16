using Cinema.Helpers;
using Cinema.Models;
using Cinema.Services.Users;
using Cinema.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Cinema.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                UserInfo userInfo = SessionHelper.GetObject<UserInfo>(HttpContext.Session, "UserInfo");
                Cinema.Models.User user = await _userService.GetUserByEmail(userInfo.Email);
                return View(user);
            }
            catch (Exception ex)
            {
            }
            return View();
          
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            try
            {
                bool response = await _userService.ChangePassword(request.Email, request.NewPassword);
                return RedirectToAction(nameof(ChangePassword));
            }
            catch (Exception ex)
            {
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Index(Models.User user)
        {
            try
            {
                bool response = await _userService.UpdateUser(user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
            }
            return View();

        }
    }
}
