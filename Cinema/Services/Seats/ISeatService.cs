using Cinema.Models;

namespace Cinema.Services.Seats
{
    public interface ISeatService
    {
        Task<List<Seat>> GetBookedSeatsByShowId(int showId);
    }
}
