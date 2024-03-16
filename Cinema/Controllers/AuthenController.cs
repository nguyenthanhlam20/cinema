using Cinema.Enums;
using Cinema.Helpers;
using Cinema.Models;
using Cinema.Requests;
using Cinema.Services.Authens;
using Cinema.Services.Films;
using Cinema.Services.Genres;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cinema.Controllers
{
    public class AuthenController : Controller
    {
        private readonly IAuthenService _authenService;

        public AuthenController(IAuthenService authenService)
        {
            _authenService = authenService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {

            try
            {
                User user = await _authenService.Login(request);
                if (user == null)
                {
                    throw new Exception("Email or password isn't correct");
                }
                var claims = new List<Claim>
                                {
                                    new Claim(ClaimTypes.Name, user.Email),
                                    new Claim(ClaimTypes.Role, "User") ,
                                };
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);


                UserInfo userInfo = new UserInfo() { UserId = user.UserId, Fullname = user.Fullname ?? "", Email = user.Email, Role = user.Role ?? 1 };
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                SessionHelper.SetObject<UserInfo>(HttpContext.Session, "UserInfo", userInfo);


                if (user.Role == (int)Role.User)
                {
                    return RedirectToAction("Index", "Home", new { area = "User" });
                }
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                ToastHelper.ShowError(TempData, ex.Message);
                return View(request);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {

            try
            {
                if (request.ConfirmPassword != request.Password)
                {
                    throw new Exception("Password not match");
                }

                User user = new User()
                {
                    Fullname = request.Fullname,
                    Email = request.Email,
                    Password = request.Password,
                    Address = request.Address,
                    Phone = request.Phone,
                    Dob = request.Dob,
                    Gender = request.Gender,
                };

                bool status = await _authenService.Register(user);

                if (!status)
                {
                    throw new Exception("Register failed");
                }

                return RedirectToAction(nameof(Login));
            }
            catch (Exception ex)
            {
                ToastHelper.ShowError(TempData, ex.Message);
                return View(request);
            }
        }

        [HttpGet]
        [Route("/SignOut")]
        public async Task<IActionResult> SignOut()
        {
            try
            {
                SessionHelper.Remove(HttpContext.Session, "UserInfo");
                SessionHelper.Remove(HttpContext.Session, "AccessToken");

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            }
            catch (Exception ex)
            {
                ToastHelper.ShowError(TempData, ex.Message);
            }
            return RedirectToAction("Index", "Home"); // Redirect to the home page
        }
    }
}
