using Cinema.Models;
using Cinema.Requests;

namespace Cinema.Services.Shows
{
    public interface IShowService
    {
        Task<List<Show>> GetShows();
        Task<bool> AddShow(Show show);
        Task<bool> UpdateShow(Show show);
        Task<bool> RemoveShow(int showId);
        Task<Show> GetShowBySlotAndDate(int slot, DateTime date);
        Task<List<Show>> GetShowByFilmAndDate(int filmId, DateTime date);
        Task<Show> GetShowById(int showId);
        Task<ShowPagingRequest> GetShows(ShowPagingRequest request);
    }
}
