using Cinema.Services.Films;
using Microsoft.AspNetCore.Mvc;
using Cinema.Models;
using Cinema.Services.Shows;
using Cinema.Helpers;
using Cinema.Services.Rooms;
using Cinema.Services.Slots;
using Cinema.Requests;
using Microsoft.AspNetCore.Authorization;
namespace Cinema.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class ShowController : Controller
    {
        private readonly IShowService _showService;
        private readonly IRoomService _roomService;
        private readonly IFilmService _filmService;
        private readonly ISlotService _slotService;

        public ShowController(IShowService showService,
            IRoomService roomService,
            IFilmService filmService,
            ISlotService slotService)
        {
            _showService = showService;
            _roomService = roomService;
            _filmService = filmService;
            _slotService = slotService;
        }

        public async Task<IActionResult> Index(ShowPagingRequest request)
        {
            try
            {
                // Set the page size for pagination
                request.PageSize = 10;

                // Retrieve shows based on the provided request asynchronously
                var response = await _showService.GetShows(request);

                // Return the view with the shows response for display
                return View(response);
            }
            catch (Exception ex)
            {
                // If an exception occurs during the retrieval process, it is caught here
                // Error handling could be implemented if needed
            }

            // Return the view with the original request object
            return View(request);

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // Retrieve films, slots, and rooms asynchronously and set them in ViewData
            ViewData["Films"] = await _filmService.GetFilms();
            ViewData["Slots"] = await _slotService.GetSlots();
            ViewData["Rooms"] = await _roomService.GetRooms();

            // Return the view 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Show show)
        {
            try
            {
                // Retrieve films, slots, and rooms asynchronously and set them in ViewData
                ViewData["Films"] = await _filmService.GetFilms();
                ViewData["Slots"] = await _slotService.GetSlots();
                ViewData["Rooms"] = await _roomService.GetRooms();

                // Set the status of the show
                show.Status = 1;

                // Attempt to add the show asynchronously
                bool response = await _showService.AddShow(show);

                // Check if show creation was unsuccessful
                if (response == false)
                {
                    // If show creation failed, throw an exception with an error message
                    throw new Exception("Create show failed.");
                }

                // If show creation is successful, display a success message to the user
                ToastHelper.ShowSuccess(TempData, "Create show successful.");

                // Redirect the user to the index page
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // If an exception occurs during the show creation process, catch it here
                // Display an error message to the user
                ToastHelper.ShowError(TempData, ex.Message);
            }

            // Return the view with the show object for the user to retry show creation
            return View(show);

        }

        [HttpGet]
        public async Task<IActionResult> Details(int showId)
        {

            // Retrieve films, slots, and rooms asynchronously and set them in ViewData
            ViewData["Films"] = await _filmService.GetFilms();
            ViewData["Slots"] = await _slotService.GetSlots();
            ViewData["Rooms"] = await _roomService.GetRooms();

            // Retrieve show details by its ID asynchronously
            Show show = await _showService.GetShowById(showId);

            // Return the view with the show details for display
            return View(show);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int showId)
        {
            // Retrieve films, slots, and rooms asynchronously and set them in ViewData
            ViewData["Films"] = await _filmService.GetFilms();
            ViewData["Slots"] = await _slotService.GetSlots();
            ViewData["Rooms"] = await _roomService.GetRooms();

            // Retrieve show details by its ID asynchronously
            Show show = await _showService.GetShowById(showId);

            // Return the view with the show details for display
            return View(show);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Show show)
        {
            try
            {
                // Retrieve films, slots, and rooms asynchronously and set them in ViewData
                ViewData["Films"] = await _filmService.GetFilms();
                ViewData["Slots"] = await _slotService.GetSlots();
                ViewData["Rooms"] = await _roomService.GetRooms();

                // Attempt to update the show asynchronously
                bool response = await _showService.UpdateShow(show);

                // Check if show update was unsuccessful
                if (response == false)
                {
                    // If show update failed, throw an exception with an error message
                    throw new Exception("Update show failed.");
                }

                // If show update is successful, display a success message to the user
                ToastHelper.ShowSuccess(TempData, "Update show successful.");

                // Redirect the user to the index page
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // If an exception occurs during the show update process, catch it here
                // Display an error message to the user
                ToastHelper.ShowError(TempData, ex.Message);
            }

            // Return the view with the show object for the user to retry show update
            return View(show);

        }
    }
}
