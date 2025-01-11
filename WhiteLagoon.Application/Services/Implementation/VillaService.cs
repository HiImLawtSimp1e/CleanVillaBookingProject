using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Application.DTOs;
using WhiteLagoon.Application.Services.Interface;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Services.Implementation
{
    public class VillaService : IVillaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VillaService(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public void CreateVilla(CreateVillaDto item)
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
        }

        public bool DeleteVilla(Guid id)
        {
            var villa = _unitOfWork.Villa.Get(v => v.Id == id);

            if (villa == null) 
            {
                return false;
            }

            if (!string.IsNullOrEmpty(villa.ImageUrl))
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, villa.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _unitOfWork.Villa.Remove(villa);
            _unitOfWork.Save();

            return true;
        }

        public IEnumerable<Villa> GetAllVillas()
        {
            var villas = _unitOfWork.Villa.GetAll(includeProperties: "Amenities");

            return villas;
        }

        public Villa GetVillaById(Guid id)
        {
            var villa = _unitOfWork.Villa.Get(u => u.Id == id, includeProperties: "Amenities");

            return villa;
        }

        public void UpdateVilla(UpdateVillaDto item)
        {
            var villa = _unitOfWork.Villa.Get(v => v.Id == item.Id);

            if (item.Image != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(item.Image.FileName);
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\VillaImage");

                if (!Directory.Exists(imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                }

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
        }

        public IEnumerable<Villa> GetVillasAvailabilityByDate(int nights, DateOnly checkInDate)
        {
            var villaList = _unitOfWork.Villa.GetAll(includeProperties: "Amenities").ToList();
            var villaNumbersList = _unitOfWork.VillaNumber.GetAll().ToList();
            var bookedVillas = _unitOfWork.Booking.GetAll(u => u.Status == SD.StatusApproved ||
            u.Status == SD.StatusCheckedIn).ToList();

            foreach (var villa in villaList)
            {
                int roomAvailable = SD.VillaRoomsAvailable_Count
                    (villa.Id, villaNumbersList, checkInDate, nights, bookedVillas);
                villa.IsAvailable = roomAvailable > 0 ? true : false;
            }

            return villaList;
        }
    }
}
