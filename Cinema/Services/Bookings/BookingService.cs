using Cinema.Models;
using Cinema.Responses;

namespace Cinema.Services.Bookings
{
    public class BookingService : IBookingService
    {
        private readonly CinemaContext _context;

        public BookingService(CinemaContext context)
        {
            _context = context;
        }
        public async Task<bool> BookingSeats(int showId, int userId, string[] seats)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return false;
        }

        public async Task<BookingHistory> GetBookingHistory(int userId)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return null;
        }
    }
}
