using Cinema.Models;
using Cinema.Services.Bookings;
using Cinema.Services.Shows;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]

    public class SeatController : Controller
    {
        private readonly IShowService _showService;
        private readonly IBookingService _bookingService;

        public SeatController(IShowService showService, IBookingService bookingService)
        {
            _showService = showService;
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> ChooseShowMovie(int filmId, DateTime date)
        {
            // Create a list to store the dates for the next 7 days starting from today
            List<DateTime> dates = new();
            for (int i = 0; i < 7; i++)
            {
                dates.Add(DateTime.Now.AddDays(i));
            }

            // Retrieve shows for the specified film and date asynchronously
            List<Show> shows = await _showService.GetShowByFilmAndDate(filmId, date);

            // Set ViewData with film ID and dates list
            ViewData["filmId"] = filmId;
            ViewData["dates"] = dates;

            // Return the view with the shows for display
            return View(shows);

        }

        [HttpGet]
        public async Task<IActionResult> ChooseSeatShow(int showId)
        {
            // Retrieve show details by its ID asynchronously
            Show show = await _showService.GetShowById(showId);

            // Set ViewData with the retrieved show details
            ViewData["Show"] = show;

            // Retrieve booked seats for the specified show asynchronously
            List<Seat> seats = await _bookingService.GetSeatsIsBooked(showId);

            // Return the view with the booked seats for display
            return View(seats);

        }

        [HttpGet]
        public async Task<IActionResult> ChooseShowMovie(int filmId)
        {
            // Calculate the date 7 days from today
            DateTime next7Days = DateTime.Now.AddDays(7);

            // Create a list to store the dates for the next 7 days starting from today
            List<DateTime> dates = new();
            for (int i = 0; i < 7; i++)
            {
                dates.Add(DateTime.Now.AddDays(i));
            }

            // Retrieve shows for the specified film and date asynchronously
            List<Show> shows = await _showService.GetShowByFilmAndDate(filmId, next7Days);

            // Set ViewData with film ID and dates list
            ViewData["filmId"] = filmId;
            ViewData["dates"] = dates;

            // Return the view with the shows for display
            return View(shows);

        }
    }
}
