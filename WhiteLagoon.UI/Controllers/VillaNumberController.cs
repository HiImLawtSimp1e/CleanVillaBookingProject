using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Application.DTOs;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Context;

namespace WhiteLagoon.UI.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VillaNumberController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var villaNumbers = _context.VillaNumbers
                .Include(vn => vn.Villa)
                .ToList();
            return View(villaNumbers);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> list = _context.Villas.ToList().Select(u => new SelectListItem
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
            bool roomNumberExists = _context.VillaNumbers.Any(vn => vn.Villa_Number == item.Villa_Number);

            if (ModelState.IsValid && !roomNumberExists)
            {
                var newVillaNumber = new VillaNumber
                {
                   Villa_Number = item.Villa_Number,
                   VillaId = item.VillaId,
                   SpecialDetails = item.SpecialDetails
                };

                _context.VillaNumbers.Add(newVillaNumber);
                _context.SaveChanges();

                TempData["success"] = "The villa number has been created successfully.";

                return RedirectToAction("Index");
            }

            if (roomNumberExists)
            {
                TempData["error"] = "The villa Number already exists.";
            }

            IEnumerable<SelectListItem> list = _context.Villas.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.VillaList = list;

            return View(item);
        }

        public IActionResult Update(int villaNumberId)
        {
            var villaNumber = _context.VillaNumbers.FirstOrDefault(v => v.Villa_Number == villaNumberId);

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

            IEnumerable<SelectListItem> list = _context.Villas.ToList().Select(u => new SelectListItem
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
                var villaNumber = _context.VillaNumbers.FirstOrDefault(vn => vn.Villa_Number == item.Villa_Number);

                villaNumber.VillaId = item.VillaId;
                villaNumber.SpecialDetails = item.SpecialDetails;

                _context.SaveChanges();

                TempData["success"] = "The villa number has been updated successfully.";

                return RedirectToAction("Index");
            }

            IEnumerable<SelectListItem> list = _context.Villas.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.VillaList = list;

            return View(item);
        }

        public IActionResult Delete(int villaNumberId)
        {
            var villaNumber = _context.VillaNumbers.FirstOrDefault(vn => vn.Villa_Number == villaNumberId);
            if (villaNumber == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }
            return View(villaNumber);
        }

        [HttpPost]
        public IActionResult Delete(VillaNumberDto item)
        {
            var villaNumber = _context.VillaNumbers.FirstOrDefault(vn => vn.Villa_Number == item.Villa_Number);
            if (villaNumber != null)
            {
                _context.VillaNumbers.Remove(villaNumber);
                _context.SaveChanges();

                TempData["success"] = "The villa has been deleted successfully.";

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
