using Cinema.Helpers;
using Cinema.Models;
using Cinema.Responses;
using Cinema.Services.Bookings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }


        [HttpPost]
        public async Task<IActionResult> BookSeats( int showId, string seatStr)
        {
            // Retrieve user information from the session
            UserInfo userInfo = SessionHelper.GetObject<UserInfo>(HttpContext.Session, "UserInfo");

            // Split the string containing seats into an array
            string[] seats = seatStr.Split(',');

            // Attempt to book seats for the specified show and user asynchronously
            await _bookingService.BookingSeats(showId, userInfo.UserId, seats);

            // Redirect the user to the "Successful" action
            return RedirectToAction("Successful");

        }

        [HttpGet]
        public IActionResult Successful()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> History()
        {
            // Retrieve user information from the session
            UserInfo userInfo = SessionHelper.GetObject<UserInfo>(HttpContext.Session, "UserInfo");

            // Retrieve booking history for the user asynchronously
            List<Booking> history = await _bookingService.GetBookingHistory(userInfo.UserId);

            // Return the view with the booking history for display
            return View(history);

        }
    }
}
