using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.DTOs;
using WhiteLagoon.Application.Services.Interface;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Services.Implementation
{
    public class AmenityService : IAmenityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AmenityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateAmenity(CreateAmenityDto item)
        {
            var amenity = new Amenity
            {
                Name = item.Name,
                Description = item.Description,
                VillaId = item.VillaId,
            };

            _unitOfWork.Amenity.Add(amenity);
            _unitOfWork.Save();
        }

        public bool DeleteAmenity(Guid id)
        {
            var amenity = _unitOfWork.Amenity.Get(u => u.Id == id);

            if(amenity == null)
            {
                return false;
            }

            _unitOfWork.Amenity.Remove(amenity);
            _unitOfWork.Save();

            return true;
        }

        public IEnumerable<Amenity> GetAllAmenities()
        {
            var amenities = _unitOfWork.Amenity.GetAll(includeProperties: "Villa");

            return amenities;
        }

        public Amenity GetAmenityById(Guid id)
        {
            return _unitOfWork.Amenity.Get(u => u.Id == id, includeProperties: "Villa");
        }

        public void UpdateAmenity(UpdateAmenityDto item)
        {
            var amenity = _unitOfWork.Amenity.Get(u => u.Id == item.Id);

            amenity.Name = item.Name;
            amenity.Description = item.Description;
            amenity.VillaId = item.VillaId;

            _unitOfWork.Amenity.Update(amenity);
            _unitOfWork.Save();
        }
    }
}
