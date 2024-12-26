using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.DTOs;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.UI.Controllers
{
    public class AmenityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AmenityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var amenities = _unitOfWork.Amenity.GetAll(includeProperties: "Villa");
            return View(amenities);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> list = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
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
                var amenity = new Amenity
                {
                    Name = item.Name,
                    Description = item.Description,
                    VillaId = item.VillaId,
                };

                _unitOfWork.Amenity.Add(amenity);
                _unitOfWork.Save();

                TempData["success"] = "The amenity has been created successfully.";

                return RedirectToAction(nameof(Index));
            }

            IEnumerable<SelectListItem> list = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.VillaList = list;

            return View(item);
        }

        public IActionResult Update(Guid amenityId)
        {
            var amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId);

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

            IEnumerable<SelectListItem> list = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
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
                var amenity = _unitOfWork.Amenity.Get(u => u.Id == item.Id);

                if (amenity == null)
                {
                    return View("~/Views/Shared/NotFound.cshtml");
                }

                amenity.Name = item.Name;
                amenity.Description = item.Description;
                amenity.VillaId = item.VillaId;

                _unitOfWork.Amenity.Update(amenity);
                _unitOfWork.Save();

                TempData["success"] = "The amenity has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            IEnumerable<SelectListItem> list = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.VillaList = list;

            return View(item);
        }

        public IActionResult Delete(Guid amenityId)
        {
            var amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId);

            if (amenity == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }

            IEnumerable<SelectListItem> list = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
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
            var amenity = _unitOfWork.Amenity.Get(u => u.Id == item.Id);

            if (amenity != null)
            {
                _unitOfWork.Amenity.Remove(amenity);
                _unitOfWork.Save();

                TempData["success"] = "The amenity has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The amenity could not be deleted.";
            return View(item);
        }
    }
}
