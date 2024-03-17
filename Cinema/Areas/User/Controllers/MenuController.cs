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
                // Retrieve all genres asynchronously and set them in ViewData
                ViewData["Genres"] = await _genreService.GetAll();

                // Retrieve films based on the provided request condition asynchronously
                var response = await _filmService.GetFilmByCondition(request);

                // Return the view with the films response for display
                return View(response);

            }
            catch (Exception ex)
            {
            }
            return View();
        }
    }
}
