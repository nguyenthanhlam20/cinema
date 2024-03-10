using Cinema.Models;
using Cinema.Requests;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.Shows
{
    public class ShowService : IShowService
    {
        private readonly CinemaContext _context;

        public ShowService(CinemaContext context)
        {
            _context = context;
        }
        public async Task<bool> AddShow(Show show)
        {
            try
            {
                _context.Shows.Add(show);

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

        public async Task<Show> GetShowByFilmAndDate(int filmId, DateTime date)
        {
            try
            {
                var show = await _context.Shows.SingleOrDefaultAsync(x => x.FilmId == filmId && x.ShowDate == date);
                return show;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return null;
        }

        public async Task<Show> GetShowById(int showId)
        {
            try
            {
                var show = await _context.Shows.SingleOrDefaultAsync(x => x.ShowId == showId);
                return show;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return null;
        }

        public async Task<Show> GetShowBySlotAndDate(int slotId, DateTime date)
        {
            try
            {
                var show = await _context.Shows.SingleOrDefaultAsync(x => x.SlotId == slotId);
                return show;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return null;
        }

        public async Task<List<Show>> GetShows()
        {
            try
            {
                var shows = await _context.Shows.ToListAsync();
                return shows;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return new List<Show>();
        }

        public async Task<ShowPagingRequest> GetShows(ShowPagingRequest request)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return request;
        }

        public async Task<bool> RemoveShow(int showId)
        {
            try
            {
                var show = await _context.Shows.SingleOrDefaultAsync(x => x.ShowId == showId);

                if (show != null)
                {
                    _context.Shows.Remove(show);
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

        public async Task<bool> UpdateShow(Show show)
        {
            try
            {
                var existed = await _context.Shows.SingleOrDefaultAsync(x => x.ShowId == show.ShowId);

                if (existed != null)
                {
                    _context.Shows.Update(existed);
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
