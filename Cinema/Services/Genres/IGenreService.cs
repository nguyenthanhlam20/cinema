using Cinema.Models;

namespace Cinema.Services.Genres
{
    public interface IGenreService
    {
        Task<List<Genre>> GetAll();
    }
}
