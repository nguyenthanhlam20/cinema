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
                // Attempt to login the user asynchronously
                User user = await _authenService.Login(request);

                // Check if the user authentication failed
                if (user == null)
                {
                    // If authentication failed, throw an exception with a specific error message
                    throw new Exception("Email or password isn't correct");
                }

                // Create claims for the authenticated user
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Role, "User")
                    };

                // Create a claims identity using the claims and default authentication scheme
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Create a UserInfo object containing details about the authenticated user
                UserInfo userInfo = new UserInfo()
                {
                    UserId = user.UserId,
                    Fullname = user.Fullname ?? "",
                    Email = user.Email,
                    Role = user.Role ?? (int)Role.User
                };

                // Sign in the user asynchronously
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                // Store user information in the session
                SessionHelper.SetObject<UserInfo>(HttpContext.Session, "UserInfo", userInfo);

                // Redirect the user based on their role
                if (user.Role == (int)Role.User)
                {
                    // If the user is a regular user, redirect them to the User area's Index action
                    return RedirectToAction("Index", "Home", new { area = "User" });
                }
                else
                {
                    // If the user is an admin, redirect them to the Admin area's Index action
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
            }
            catch (Exception ex)
            {
                // If an exception occurs during the authentication process, catch it here
                // Display an error message to the user
                ToastHelper.ShowError(TempData, ex.Message);

                // Return the login view with the original login request object for the user to retry
                return View(request);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {

            try
            {
                // Check if the confirmed password matches the entered password
                if (request.ConfirmPassword != request.Password)
                {
                    // If passwords do not match, throw an exception with an error message
                    throw new Exception("Password not match");
                }

                // Create a new User object with details from the registration request
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

                // Attempt to register the user asynchronously
                bool status = await _authenService.Register(user);

                // Check if registration was unsuccessful
                if (!status)
                {
                    // If registration failed, throw an exception with an error message
                    throw new Exception("Register failed");
                }

                // If registration is successful, redirect the user to the login page
                return RedirectToAction(nameof(Login));
            }
            catch (Exception ex)
            {
                // If an exception occurs during the registration process, catch it here
                // Display an error message to the user
                ToastHelper.ShowError(TempData, ex.Message);

                // Return the registration view with the original registration request object for the user to retry
                return View(request);
            }

        }

        [HttpGet]
        [Route("/SignOut")]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                // Remove user information and access token from the session
                SessionHelper.Remove(HttpContext.Session, "UserInfo");
                SessionHelper.Remove(HttpContext.Session, "AccessToken");

                // Sign out the user asynchronously
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                // If an exception occurs during sign out, catch it here
                // Display an error message to the user
                ToastHelper.ShowError(TempData, ex.Message);
            }

            // Redirect the user to the home page
            return RedirectToAction("Index", "Home");

        }
    }
}
