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
                // Retrieve all genres and countries asynchronously and set them in ViewData
                ViewData["Genres"] = await _genreService.GetAll();
                ViewData["Countries"] = await _countryService.GetAll();

                // Attempt to add the film asynchronously
                bool response = await _filmService.AddFilm(film);

                // Check if film creation was unsuccessful
                if (response == false)
                {
                    // If film creation failed, throw an exception with an error message
                    throw new Exception("Create film failed.");
                }

                // If film creation is successful, display a success message to the user
                ToastHelper.ShowSuccess(TempData, "Create film successful.");

                // Redirect the user to the index page
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // If an exception occurs during the film creation process, catch it here
                // Display an error message to the user
                ToastHelper.ShowError(TempData, ex.Message);
            }

            // Return the view with the film object for the user to retry film creation
            return View(film);

        }

        [HttpGet]
        public async Task<IActionResult> Details(int filmId)
        {
            // Retrieve all genres and countries asynchronously and set them in ViewData
            ViewData["Genres"] = await _genreService.GetAll();
            ViewData["Countries"] = await _countryService.GetAll();

            // Retrieve film details by its ID asynchronously
            Film film = await _filmService.GetFilmById(filmId);

            // Return the view with the film details for display
            return View(film);

        }

        [HttpGet]
        public async Task<IActionResult> Update(int filmId)
        {
            // Retrieve all genres and countries asynchronously and set them in ViewData
            ViewData["Genres"] = await _genreService.GetAll();
            ViewData["Countries"] = await _countryService.GetAll();

            // Retrieve film details by its ID asynchronously
            Film film = await _filmService.GetFilmById(filmId);

            // Return the view with the film details for display
            return View(film);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Film film)
        {
            try
            {
                // Retrieve all genres and countries asynchronously and set them in ViewData
                ViewData["Genres"] = await _genreService.GetAll();
                ViewData["Countries"] = await _countryService.GetAll();

                // Attempt to update the film asynchronously
                bool response = await _filmService.UpdateFilm(film);

                // Check if film update was unsuccessful
                if (response == false)
                {
                    // If film update failed, throw an exception with an error message
                    throw new Exception("Update film failed.");
                }

                // If film update is successful, display a success message to the user
                ToastHelper.ShowSuccess(TempData, "Update film successful.");

                // Redirect the user to the index page
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // If an exception occurs during the film update process, catch it here
                // Display an error message to the user
                ToastHelper.ShowError(TempData, ex.Message);
            }

            // Return the view with the film object for the user to retry film update
            return View(film);

        }
    }
}
