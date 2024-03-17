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
                // Retrieve user information from the session
                UserInfo userInfo = SessionHelper.GetObject<UserInfo>(HttpContext.Session, "UserInfo");

                // Retrieve user details by email asynchronously
                Cinema.Models.User user = await _userService.GetUserByEmail(userInfo.Email);

                // Return the view with the user details for display
                return View(user);
            }
            catch (Exception ex)
            {
                // If an exception occurs during the retrieval process, it is caught here
                // Error handling could be implemented if needed
            }

            // Return the view without any user details
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
                if(request.NewPassword != request.ConfirmPassword)
                {
                    throw new Exception("Password not match");
                }

                // Attempt to change the password for the user asynchronously
                bool response = await _userService.ChangePassword(request.Email, request.NewPassword);

                // Redirect the user to the "ChangePassword" action if successful
                return RedirectToAction(nameof(ChangePassword));
            }
            catch (Exception ex)
            {
                ToastHelper.ShowError(TempData, ex.Message);
            }

            // Return the view without any specific action if password change fails
            return View(request);


        }
        [HttpPost]
        public async Task<IActionResult> Index(Models.User user)
        {
            try
            {
                // Attempt to update the user asynchronously
                bool response = await _userService.UpdateUser(user);

                // Redirect the user to the "Index" action if successful
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // If an exception occurs during the user update process, it is caught here
                // Error handling could be implemented if needed
            }

            // Return the view without any specific action if user update fails
            return View();


        }
    }
}
