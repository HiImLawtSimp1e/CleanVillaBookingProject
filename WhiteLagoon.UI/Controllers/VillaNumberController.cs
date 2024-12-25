using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.DTOs;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Context;

namespace WhiteLagoon.UI.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VillaNumberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var villaNumbers = _unitOfWork.VillaNumber.GetAll(includeProperties: "Villa");
            return View(villaNumbers);
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
        public IActionResult Create(VillaNumberDto item)
        {
            bool roomNumberExists = _unitOfWork.VillaNumber.Any(vn => vn.Villa_Number == item.Villa_Number);

            if (ModelState.IsValid && !roomNumberExists)
            {
                var newVillaNumber = new VillaNumber
                {
                   Villa_Number = item.Villa_Number,
                   VillaId = item.VillaId,
                   SpecialDetails = item.SpecialDetails
                };

                _unitOfWork.VillaNumber.Add(newVillaNumber);
                _unitOfWork.Save();

                TempData["success"] = "The villa number has been created successfully.";

                return RedirectToAction("Index");
            }

            if (roomNumberExists)
            {
                TempData["error"] = "The villa Number already exists.";
            }

            IEnumerable<SelectListItem> list = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.VillaList = list;

            return View(item);
        }

        public IActionResult Update(int villaNumberId)
        {
            var villaNumber = _unitOfWork.VillaNumber.Get(v => v.Villa_Number == villaNumberId);

            if (villaNumber == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }

            var item = new VillaNumberDto
            {
                VillaId = villaNumber.VillaId,
                Villa_Number = villaNumber.Villa_Number,
                SpecialDetails = villaNumber.SpecialDetails
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
        public IActionResult Update(VillaNumberDto item)
        {
            if (ModelState.IsValid)
            {
                var villaNumber = _unitOfWork.VillaNumber.Get(vn => vn.Villa_Number == item.Villa_Number);

                villaNumber.VillaId = item.VillaId;
                villaNumber.SpecialDetails = item.SpecialDetails;

                _unitOfWork.VillaNumber.Update(villaNumber);
                _unitOfWork.Save();

                TempData["success"] = "The villa number has been updated successfully.";

                return RedirectToAction("Index");
            }

            IEnumerable<SelectListItem> list = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.VillaList = list;

            return View(item);
        }

        public IActionResult Delete(int villaNumberId)
        {
            var villaNumber = _unitOfWork.VillaNumber.Get(vn => vn.Villa_Number == villaNumberId);
            if (villaNumber == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }
            return View(villaNumber);
        }

        [HttpPost]
        public IActionResult Delete(VillaNumberDto item)
        {
            var villaNumber = _unitOfWork.VillaNumber.Get(vn => vn.Villa_Number == item.Villa_Number);
            if (villaNumber != null)
            {
                _unitOfWork.VillaNumber.Remove(villaNumber);
                _unitOfWork.Save();

                TempData["success"] = "The villa has been deleted successfully.";

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
