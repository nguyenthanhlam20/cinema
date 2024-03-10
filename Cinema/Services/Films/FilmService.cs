using Cinema.Models;
using Cinema.Requests;
using Cinema.Responses;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.Films
{
    public class FilmService : IFilmService
    {
        private readonly CinemaContext _context;

        public FilmService(CinemaContext context)
        {
            _context = context;
        }
        public async Task<bool> AddFilm(Film film)
        {
            try
            {
                await _context.AddAsync(film);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return false;
        }

        public async Task<List<Film>> GetFilms()
        {
            try
            {
                var films = await _context.Films.ToListAsync();
                return films;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return new List<Film>();
        }

        public async Task<FilmPagingRequest> GetFilmByCondition(FilmPagingRequest request)
        {
            try
            {
                var query = await _context.Films.ToListAsync();
                if (request.GenreId != 0)
                {
                    query = query.Where(x => x.GenreId == request.GenreId).ToList();
                }

                //Set totoal pages for paging
                request.TotalRecord = query.Count();
                request.TotalPages = (int)Math.Ceiling(request.TotalRecord / (double)request.PageSize);
                query = query.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize).ToList();

                request.Items = query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return request;
        }

        public async Task<Film> GetFilmById(int id)
        {
            try
            {
                var film = await _context.Films.SingleOrDefaultAsync(x => x.FilmId == id);

                return film;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return new Film();
        }

        public async Task<FilmSlideResponse> GetFilmSlides()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return new FilmSlideResponse();
        }

        public async Task<bool> RemoveFilm(int id)
        {
            try
            {
                var film = await _context.Films.SingleOrDefaultAsync(x => x.FilmId == id);

                if (film != null)
                {
                    _context.Films.Remove(film);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return false;
        }

        public async Task<bool> UpdateFilm(Film film)
        {
            try
            {
                var existed = await _context.Films.SingleOrDefaultAsync(x => x.FilmId == film.FilmId);
                if (existed != null)
                {
                    _context.Update(existed);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return false;
        }
    }
}
