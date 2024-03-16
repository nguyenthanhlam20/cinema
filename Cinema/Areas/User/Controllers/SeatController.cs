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
            List<DateTime> dates = new();
            for(int i = 0; i < 7; i++)
            {
                dates.Add(DateTime.Now.AddDays(i));
            }

            List<Show> shows = await _showService.GetShowByFilmAndDate(filmId, date);


            ViewData["filmId"] = filmId;
            ViewData["dates"] = dates;

            return View(shows);
        }

        [HttpGet]
        public async Task<IActionResult> ChooseSeatShow(int showId)
        {
            Show show = await _showService.GetShowById(showId);
            ViewData["Show"] = show;
            List<Seat> seats = await _bookingService.GetSeatsIsBooked(showId);
            Console.Write("Total: " + seats.Count);
            return View(seats);
        }

        [HttpGet]
        public async Task<IActionResult> ChooseShowMovie(int filmId)
        {
            DateTime next7Days = DateTime.Now.AddDays(7);
            List<DateTime> dates = new();
            for (int i = 0; i < 7; i++)
            {
                dates.Add(DateTime.Now.AddDays(i));
            }

            List<Show> shows = await _showService.GetShowByFilmAndDate(filmId, next7Days);
            Console.WriteLine("Total show: " + shows.Count);
            Console.WriteLine("filmId: " + filmId);

            ViewData["filmId"] = filmId;
            ViewData["dates"] = dates;

            return View(shows);
        }
    }
}
