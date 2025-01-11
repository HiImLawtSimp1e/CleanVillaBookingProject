using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WhiteLagoon.Application.Services.Interface;
using WhiteLagoon.UI.Models;
using WhiteLagoon.UI.ViewModels;

namespace WhiteLagoon.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVillaService _villaService;

        public HomeController(IVillaService villaService)
        {
            _villaService = villaService;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                VillaList = _villaService.GetAllVillas(),
                Nights = 1,
                CheckInDate = DateOnly.FromDateTime(DateTime.Now),
            };
            return View(homeVM);
        }

        [HttpPost]
        public IActionResult GetVillasByDate(int nights, DateOnly checkInDate)
        {
            var villaList = _villaService.GetVillasAvailabilityByDate(nights, checkInDate);

            HomeVM homeVM = new()
            {
                CheckInDate = checkInDate,
                VillaList = villaList,
                Nights = nights,
                CheckOutDate = checkInDate.AddDays(nights)
            };
            return PartialView("_VillaListPartial", homeVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
