using Cinema.Requests;
using Cinema.Services.Films;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        public async Task<IActionResult> Index(FilmPagingRequest request)
        {
            try
            {
                request.PageSize = 5;
                var response = await _filmService.GetFilmByCondition(request);

                return View(response);
            }
            catch (Exception ex)
            {
            }
            return View(request);
        }


    }
}
