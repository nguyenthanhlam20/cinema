using Cinema.Helpers;
using Cinema.Models;
using Cinema.Requests;
using Cinema.Services.Countries;
using Cinema.Services.Films;
using Cinema.Services.Genres;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly IGenreService _genreService;
        private readonly ICountryService _countryService;

        public FilmController(IFilmService filmService, IGenreService genreService, ICountryService countryService)
        {
            _filmService = filmService;
            _genreService = genreService;
            _countryService = countryService;
        }

        public async Task<IActionResult> Index(FilmPagingRequest request)
        {
            try
            {
                request.PageSize = 10;
                var response = await _filmService.GetFilmByCondition(request);

                return View(response);
            }
            catch (Exception ex)
            {
            }
            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Genres"] = await _genreService.GetAll();
            ViewData["Countries"] = await _countryService.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Film film)
        {
            try
            {
                ViewData["Genres"] = await _genreService.GetAll();
                ViewData["Countries"] = await _countryService.GetAll();

                bool response = await _filmService.AddFilm(film);

                if (response == false)
                {
                    throw new Exception("Create film failed.");
                }
                ToastHelper.ShowSuccess(TempData, "Create film successful.");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ToastHelper.ShowError(TempData, ex.Message);
            }
            return View(film);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int filmId)
        {
            ViewData["Genres"] = await _genreService.GetAll();
            ViewData["Countries"] = await _countryService.GetAll();
            Film film = await _filmService.GetFilmById(filmId);
            return View(film);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int filmId)
        {
            ViewData["Genres"] = await _genreService.GetAll();
            ViewData["Countries"] = await _countryService.GetAll();
            Film film = await _filmService.GetFilmById(filmId);
            return View(film);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Film film)
        {
            try
            {
                ViewData["Genres"] = await _genreService.GetAll();
                ViewData["Countries"] = await _countryService.GetAll();
                bool response = await _filmService.UpdateFilm(film);
                if (response == false)
                {
                    throw new Exception("Update film failed.");
                }
                ToastHelper.ShowSuccess(TempData, "Update film successful.");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ToastHelper.ShowError(TempData, ex.Message);
            }
            return View(film);
        }
    }
}
