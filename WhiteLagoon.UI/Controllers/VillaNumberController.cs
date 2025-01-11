using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Application.DTOs;
using WhiteLagoon.Application.Services.Implementation;
using WhiteLagoon.Application.Services.Interface;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.UI.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        private readonly IVillaService _villaService;

        public VillaNumberController(IVillaNumberService villaNumberService, IVillaService villaService)
        {
            _villaNumberService = villaNumberService;
            _villaService = villaService;
        }
        public IActionResult Index()
        {
            var villaNumbers = _villaNumberService.GetAllVillaNumbers();
            return View(villaNumbers);
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
        public IActionResult Create(VillaNumberDto item)
        {
            bool roomNumberExists = _villaNumberService.CheckVillaNumberExists(item.Villa_Number);

            if (ModelState.IsValid && !roomNumberExists)
            {
                _villaNumberService.CreateVillaNumber(item);

                TempData["success"] = "The villa number has been created successfully.";

                return RedirectToAction("Index");
            }

            if (roomNumberExists)
            {
                TempData["error"] = "The villa Number already exists.";
            }

            IEnumerable<SelectListItem> list = _villaService.GetAllVillas().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.VillaList = list;

            return View(item);
        }

        public IActionResult Update(int villaNumberId)
        {
            var villaNumber = _villaNumberService.GetVillaNumberById(villaNumberId);

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

            IEnumerable<SelectListItem> list = _villaService.GetAllVillas().Select(u => new SelectListItem
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
                _villaNumberService.UpdateVillaNumber(item);

                TempData["success"] = "The villa number has been updated successfully.";
                return RedirectToAction("Index");
            }

            IEnumerable<SelectListItem> list = _villaService.GetAllVillas().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.VillaList = list;

            return View(item);
        }

        public IActionResult Delete(int villaNumberId)
        {
            var villaNumber = _villaNumberService.GetVillaNumberById(villaNumberId);
            if (villaNumber == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }
            return View(villaNumber);
        }

        [HttpPost]
        public IActionResult Delete(VillaNumberDto item)
        {
            var res = _villaNumberService.DeleteVillaNumber(item);

            if (res == true)
            {
                TempData["success"] = "The villa has been deleted successfully.";

                return RedirectToAction("Index");
            }

            TempData["error"] = "The villa number cannot delete";

            return View(item);
        }
    }
}
