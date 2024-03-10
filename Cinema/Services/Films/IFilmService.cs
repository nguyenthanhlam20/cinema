using Cinema.Models;
using Cinema.Requests;
using Cinema.Responses;

namespace Cinema.Services.Films
{
    public interface IFilmService
    {
        Task<List<Film>> GetFilms();
        Task<FilmPagingRequest> GetFilmByCondition(FilmPagingRequest request);

        Task<bool> AddFilm(Film film);
        Task<bool> RemoveFilm(int id);
        Task<bool> UpdateFilm(Film film);

        Task<Film> GetFilmById(int id);
        Task<FilmSlideResponse> GetFilmSlides();

    }
}
