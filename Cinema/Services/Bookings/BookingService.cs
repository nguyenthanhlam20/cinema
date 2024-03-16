using Cinema.Models;
using Cinema.Responses;
using Microsoft.EntityFrameworkCore;

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
                Booking booking = new Booking() { ShowId = showId, UserId = userId };
                List<Seat> seatList = new();

                for (int i = 0; i < seats.Length; i++)
                {
                    Seat? seat = _context.Seats.SingleOrDefault(x => x.SeatId == int.Parse(seats[i]));
                    seatList.Add(seat);
                }
                booking.Seats = seatList;

                _context.Bookings.Add(booking);
                if (await _context.SaveChangesAsync() > 0)
                {
                    Console.WriteLine("ok");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return false;
        }

        public async Task<List<Booking>> GetBookingHistory(int userId)
        {
            try
            {
                List<Booking> bookings = await _context.Bookings
                    .Include(x => x.Seats)
                    .Include(x => x.Show)
                    .ThenInclude(x => x.Slot)
                    .Include(x => x.Show)
                    .ThenInclude(x => x.Film)
                    .Where(x => x.UserId == userId).ToListAsync();
                return bookings;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return null;
        }

        public async Task<List<Seat>> GetSeatsIsBooked(int showId)
        {
            Show show = await _context.Shows
                .Include(x => x.Bookings)
                .ThenInclude(x => x.Seats)
                .SingleAsync(x => x.ShowId == showId);
            List<Seat> allSeats = new List<Seat>();

            foreach (var booking in show.Bookings)
            {
                allSeats.AddRange(booking.Seats);
            }

            return allSeats;

        }

        public async Task<int> GetTotalBooking()
        {
            try
            {
                var records = await _context.Bookings.ToListAsync();
                return records.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return 0;
        }
    }
}
