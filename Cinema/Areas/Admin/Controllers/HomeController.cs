using Cinema.Services.Bookings;
using Cinema.Services.Films;
using Cinema.Services.Shows;
using Cinema.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class HomeController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly IShowService _showService;
        private readonly IUserService _userService;
        private readonly IBookingService _bookingService;

        public HomeController(IFilmService filmService,
            IShowService showService,
            IUserService userService,
            IBookingService bookingService)
        {
            _filmService = filmService;
            _showService = showService;
            _userService = userService;
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // Attempt to retrieve data including films, shows, total users, and total booking revenues asynchronously
                var films = await _filmService.GetFilms();
                var shows = await _showService.GetShows();
                var users = await _userService.GetTotalUsers();
                var revenues = await _bookingService.GetTotalBooking();

                // Set ViewData with the obtained data
                ViewData["totalMovie"] = films.Count;
                ViewData["totalUser"] = users;
                ViewData["totalShow"] = shows.Count;
                ViewData["totalRevenue"] = revenues;
            }
            catch (Exception ex)
            {
                // If an exception occurs while retrieving data, it is caught here
                // Error handling could be implemented if needed
            }

            // Return the view
            return View();

        }
    }
}
