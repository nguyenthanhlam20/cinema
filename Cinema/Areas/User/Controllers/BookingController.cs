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
            UserInfo userInfo = SessionHelper.GetObject<UserInfo>(HttpContext.Session, "UserInfo");
            string[] seats = seatStr.Split(',');
            await _bookingService.BookingSeats(showId, userInfo.UserId, seats);
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
            UserInfo userInfo = SessionHelper.GetObject<UserInfo>(HttpContext.Session, "UserInfo");
            PropertyLogger.LogAllProperties(userInfo);
            List<Booking> history = await _bookingService.GetBookingHistory(userInfo.UserId);

            return View(history);
        }
    }
}
