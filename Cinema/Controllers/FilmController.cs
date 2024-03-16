using Cinema.Models;
using Cinema.Services.Films;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int filmId)
        {
            Film film = await _filmService.GetFilmById(filmId);
            return View(film);
        }
    }
}
