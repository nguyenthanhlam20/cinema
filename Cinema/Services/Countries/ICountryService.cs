using Cinema.Models;

namespace Cinema.Services.Countries
{
    public interface ICountryService
    {
        Task<List<Country>> GetAll();
    }
}
