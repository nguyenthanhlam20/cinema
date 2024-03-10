using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.Countries
{
    public class CountryService : ICountryService
    {
        private readonly CinemaContext _context;

        public CountryService(CinemaContext context)
        {
            _context = context;
        }
        public async Task<List<Country>> GetAll()
        {
            try
            {
                var countries = await _context.Countries.ToListAsync();
                return countries;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return new List<Country>();
        }
    }
}
