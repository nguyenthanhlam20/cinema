using Cinema.Responses;

namespace Cinema.Services.Bookings
{
    public interface IBookingService
    {
        Task<bool> BookingSeats(int showId, int userId, string[] seats);
        Task<BookingHistory> GetBookingHistory(int userId);

    }
}
