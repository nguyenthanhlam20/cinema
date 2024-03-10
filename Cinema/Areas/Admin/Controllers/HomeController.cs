using Cinema.Services.Films;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IFilmService _filmService;

        public HomeController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var films = await _filmService.GetFilms();

                return View(films);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
