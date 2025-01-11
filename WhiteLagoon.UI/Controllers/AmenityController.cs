using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Application.DTOs;
using WhiteLagoon.Application.Services.Implementation;
using WhiteLagoon.Application.Services.Interface;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.UI.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class AmenityController : Controller
    {
        private readonly IAmenityService _amenityService;
        private readonly IVillaService _villaService;

        public AmenityController(IAmenityService amenityService, IVillaService villaService)
        {
            _amenityService = amenityService;
            _villaService = villaService;
        }

        public IActionResult Index()
        {
            var amenities = _amenityService.GetAllAmenities();
            return View(amenities);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> list = _villaService.GetAllVillas().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.VillaList = list;

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAmenityDto item)
        {
            if (ModelState.IsValid)
            {
                _amenityService.CreateAmenity(item);

                TempData["success"] = "The amenity has been created successfully.";

                return RedirectToAction(nameof(Index));
            }

            IEnumerable<SelectListItem> list = _villaService.GetAllVillas().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.VillaList = list;

            return View(item);
        }

        public IActionResult Update(Guid amenityId)
        {
            var amenity = _amenityService.GetAmenityById(amenityId);

            if (amenity == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }

            var item = new UpdateAmenityDto
            {
                Id = amenity.Id,
                Name = amenity.Name,
                Description = amenity.Description,
                VillaId = amenity.VillaId
            };

            IEnumerable<SelectListItem> list = _villaService.GetAllVillas().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.VillaList = list;
           
            return View(item);
        }

        [HttpPost]
        public IActionResult Update(UpdateAmenityDto item)
        {
            if (ModelState.IsValid)
            {
                _amenityService.UpdateAmenity(item);

                TempData["success"] = "The amenity has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            IEnumerable<SelectListItem> list = _villaService.GetAllVillas().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.VillaList = list;

            return View(item);
        }

        public IActionResult Delete(Guid amenityId)
        {
            var amenity = _amenityService.GetAmenityById(amenityId);

            if (amenity == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }

            IEnumerable<SelectListItem> list = _villaService.GetAllVillas().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.VillaList = list;

            return View(amenity);
        }

        [HttpPost]
        public IActionResult Delete(Amenity item)
        {
            var res = _amenityService.DeleteAmenity(item.Id);

            if (res == true)
            {
                TempData["success"] = "The amenity has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The amenity could not be deleted.";
            return View(item);
        }
    }
}
