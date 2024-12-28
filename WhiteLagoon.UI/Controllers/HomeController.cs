using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.UI.Models;
using WhiteLagoon.UI.ViewModels;

namespace WhiteLagoon.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll(includeProperties: "Amenities"),
                Nights = 1,
                CheckInDate = DateOnly.FromDateTime(DateTime.Now),
            };
            return View(homeVM);
        }

        [HttpPost]
        public IActionResult Index(HomeVM homeVM)
        {
            int i = 0;
            homeVM.VillaList = _unitOfWork.Villa.GetAll(includeProperties: "Amenities");
            foreach (var villa in homeVM.VillaList)
            {
                if (i % 2 == 0)
                {
                    villa.IsAvailable = false;
                }
                i++;
            }
            return View(homeVM);
        }

        public IActionResult GetVillasByDate(int nights, DateOnly checkInDate)
        {
            int i = 0;
            var villaList = _unitOfWork.Villa.GetAll(includeProperties: "Amenities").ToList();
            foreach (var villa in villaList)
            {
                if (i % 2 == 0)
                {
                    villa.IsAvailable = false;
                }
                i++;
            }
            HomeVM homeVM = new()
            {
                CheckInDate = checkInDate,
                VillaList = villaList,
                Nights = nights
            };
            return PartialView("_VillaListPartial", homeVM);
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
