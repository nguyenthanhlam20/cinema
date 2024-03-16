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
                request.PageSize = 10;
                var response = await _showService.GetShows(request);

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
            ViewData["Films"] = await _filmService.GetFilms();
            ViewData["Slots"] = await _slotService.GetSlots();
            ViewData["Rooms"] = await _roomService.GetRooms();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Show show)
        {
            try
            {
                ViewData["Films"] = await _filmService.GetFilms();
                ViewData["Slots"] = await _slotService.GetSlots();
                ViewData["Rooms"] = await _roomService.GetRooms();
                show.Status = 1;
                bool response = await _showService.AddShow(show);

                if (response == false)
                {
                    throw new Exception("Create show failed.");
                }
                ToastHelper.ShowSuccess(TempData, "Create show successful.");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ToastHelper.ShowError(TempData, ex.Message);
            }
            return View(show);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int showId)
        {

            ViewData["Films"] = await _filmService.GetFilms();
            ViewData["Slots"] = await _slotService.GetSlots();
            ViewData["Rooms"] = await _roomService.GetRooms();
            Show show = await _showService.GetShowById(showId);

            return View(show);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int showId)
        {
            ViewData["Films"] = await _filmService.GetFilms();
            ViewData["Slots"] = await _slotService.GetSlots();
            ViewData["Rooms"] = await _roomService.GetRooms();
            Show show = await _showService.GetShowById(showId);
            PropertyLogger.LogAllProperties(show);

            return View(show);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Show show)
        {
            try
            {
                ViewData["Films"] = await _filmService.GetFilms();
                ViewData["Slots"] = await _slotService.GetSlots();
                ViewData["Rooms"] = await _roomService.GetRooms();
                bool response = await _showService.UpdateShow(show);
                if (response == false)
                {
                    throw new Exception("Update show failed.");
                }
                ToastHelper.ShowSuccess(TempData, "Update show successful.");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ToastHelper.ShowError(TempData, ex.Message);
            }
            return View(show);
        }
    }
}
