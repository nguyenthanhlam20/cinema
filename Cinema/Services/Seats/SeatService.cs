using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.Seats
{
    public class SeatService : ISeatService
    {
        private readonly CinemaContext _context;

        public SeatService(CinemaContext context)
        {
            _context = context;
        }
        public async Task<List<Seat>> GetBookedSeatsByShowId(int showId)
        {
            try
            {
                var booking = await _context.Bookings.Include(x => x.Show).SingleOrDefaultAsync(x => x.ShowId == showId);

                if(booking != null)
                {
                    var seats = booking.Seats.ToList();
                    return seats;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return new List<Seat>();
        }
    }
}
