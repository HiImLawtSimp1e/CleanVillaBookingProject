using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Application.DTOs;
using WhiteLagoon.Application.Services.Interface;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.UI.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;

        public VillaController(IVillaService villaService)
        {
            _villaService = villaService;
        }

        public IActionResult Index()
        {
            var villas = _villaService.GetAllVillas();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVillaDto item)
        {
            if (item.Name == item.Description)
            {
                ModelState.AddModelError("name", "The description cannot exactly match the Name.");
            }

            if (ModelState.IsValid) 
            {
                _villaService.CreateVilla(item);

                TempData["success"] = "The villa has been created successfully.";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        public IActionResult Update(Guid villaId)
        {
            var villa = _villaService.GetVillaById(villaId);

            if (villa == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }

            var item = new UpdateVillaDto
            {
                Id = villa.Id,
                Name = villa.Name,
                Description = villa.Description,
                Price = villa.Price,
                Sqft = villa.Sqft,
                Occupancy = villa.Occupancy,
                ImageUrl = villa.ImageUrl,
            };

            return View(item);
        }

        [HttpPost]
        public IActionResult Update(UpdateVillaDto item)
        {
            if (ModelState.IsValid)
            {
                _villaService.UpdateVilla(item);

                TempData["success"] = "The villa has been updated successfully.";

                return RedirectToAction("Index");
            }
            return View(item);
        }

        public IActionResult Delete(Guid villaId)
        {
            var villa = _villaService.GetVillaById(villaId);
            if (villa == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }
            return View(villa);
        }

        [HttpPost]
        public IActionResult Delete(Villa item)
        {
            var res = _villaService.DeleteVilla(item.Id);

            if(res == true)
            {
                TempData["success"] = "The villa has been deleted successfully.";

                return RedirectToAction("Index");
            }

            TempData["error"] = "The villa cannot delete";

            return View(item);
        }
    }
}
