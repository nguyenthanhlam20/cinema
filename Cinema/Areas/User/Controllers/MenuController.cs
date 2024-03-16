using Cinema.Requests;
using Cinema.Services.Films;
using Cinema.Services.Genres;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]

    public class MenuController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly IGenreService _genreService;

        public MenuController(IFilmService filmService, IGenreService genreService)
        {
            _filmService = filmService;
            _genreService = genreService;
        }

        public async Task<IActionResult> Index(FilmPagingRequest request)
        {
            try
            {
                ViewData["Genres"] = await _genreService.GetAll();

                var response = await _filmService.GetFilmByCondition(request);
                return View(response);
            }
            catch (Exception ex)
            {
            }
            return View();
        }
    }
}
