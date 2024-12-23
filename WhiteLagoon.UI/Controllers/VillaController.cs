using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.DTOs;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Context;

namespace WhiteLagoon.UI.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VillaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var villas = _context.Villas.ToList();
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
                var newVilla = new Villa
                {
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Sqft = item.Sqft,
                    Occupancy = item.Occupancy,
                    ImageUrl = item.ImageUrl,
                };

                _context.Villas.Add(newVilla);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(item);
        }

        public IActionResult Update(Guid villaId)
        {
            var villa = _context.Villas.FirstOrDefault(v => v.Id == villaId);

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
                var villa = _context.Villas.FirstOrDefault(v => v.Id == item.Id);

                if (villa == null)
                {
                    return View("~/Views/Shared/NotFound.cshtml");
                }

                villa.Name = item.Name;
                villa.Description = item.Description;
                villa.Price = item.Price;
                villa.Sqft = item.Sqft;
                villa.Occupancy = item.Occupancy;
                villa.ImageUrl = item.ImageUrl;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public IActionResult Delete(Guid villaId)
        {
            var villa = _context.Villas.FirstOrDefault(v => v.Id == villaId);
            if (villa == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }
            return View(villa);
        }

        [HttpPost]
        public IActionResult Delete(Villa item)
        {
            var villa = _context.Villas.FirstOrDefault(v => v.Id == item.Id);
            if (villa != null)
            {
                _context.Villas.Remove(villa);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
