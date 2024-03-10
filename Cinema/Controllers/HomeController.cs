using Cinema.Models;
using Cinema.Services.Films;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFilmService _filmService;

        public HomeController(ILogger<HomeController> logger, IFilmService filmService)
        {
            _logger = logger;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
