using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Application.DTOs;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.UI.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class VillaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VillaController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var villas = _unitOfWork.Villa.GetAll();
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
                if (item.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(item.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\VillaImage");

                    if (!Directory.Exists(imagePath))
                    {
                        Directory.CreateDirectory(imagePath);
                    }

                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    item.Image.CopyTo(fileStream);
                    item.ImageUrl = @"\images\VillaImage\" + fileName;
                }
                else
                {
                    item.ImageUrl = "https://placehold.co/600x400";
                }

                var newVilla = new Villa
                {
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Sqft = item.Sqft,
                    Occupancy = item.Occupancy,
                    ImageUrl = item.ImageUrl,
                };

                _unitOfWork.Villa.Add(newVilla);
                _unitOfWork.Save();

                TempData["success"] = "The villa has been created successfully.";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        public IActionResult Update(Guid villaId)
        {
            var villa = _unitOfWork.Villa.Get(v => v.Id == villaId);

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
                var villa = _unitOfWork.Villa.Get(v => v.Id == item.Id);

                if (villa == null)
                {
                    return View("~/Views/Shared/NotFound.cshtml");
                }

                if (item.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(item.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\VillaImage");
                    if (!string.IsNullOrEmpty(item.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, item.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    item.Image.CopyTo(fileStream);
                    item.ImageUrl = @"\images\VillaImage\" + fileName;
                }

                villa.Name = item.Name;
                villa.Description = item.Description;
                villa.Price = item.Price;
                villa.Sqft = item.Sqft;
                villa.Occupancy = item.Occupancy;
                villa.ImageUrl = item.ImageUrl;

                _unitOfWork.Villa.Update(villa);
                _unitOfWork.Save();

                TempData["success"] = "The villa has been updated successfully.";

                return RedirectToAction("Index");
            }
            return View(item);
        }

        public IActionResult Delete(Guid villaId)
        {
            var villa = _unitOfWork.Villa.Get(v => v.Id == villaId);
            if (villa == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }
            return View(villa);
        }

        [HttpPost]
        public IActionResult Delete(Villa item)
        {
            var villa = _unitOfWork.Villa.Get(v => v.Id == item.Id);
            if (villa != null)
            {
                if (!string.IsNullOrEmpty(item.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, item.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                _unitOfWork.Villa.Remove(villa);
                _unitOfWork.Save();

                TempData["success"] = "The villa has been deleted successfully.";

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
