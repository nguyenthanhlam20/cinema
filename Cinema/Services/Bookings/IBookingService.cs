using Cinema.Models;
using Cinema.Responses;

namespace Cinema.Services.Bookings
{
    public interface IBookingService
    {
        Task<bool> BookingSeats(int showId, int userId, string[] seats);
        Task<List<Booking>> GetBookingHistory(int userId);
        Task<int> GetTotalBooking();
        Task<List<Seat>> GetSeatsIsBooked(int showId);

    }
}
