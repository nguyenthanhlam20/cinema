using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.Genres
{
    public class GenreService : IGenreService
    {
        private readonly CinemaContext _context;

        public GenreService(CinemaContext context)
        {
            _context = context;
        }
        public async Task<List<Genre>> GetAll()
        {
            try
            {
                var genres = await _context.Genres.ToListAsync();
                return genres;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return new List<Genre>();
        }
    }
}
