using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.DTOs;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Services.Interface
{
    public interface IAmenityService
    {
        IEnumerable<Amenity> GetAllAmenities();
        void CreateAmenity(CreateAmenityDto item);
        void UpdateAmenity(UpdateAmenityDto item);
        Amenity GetAmenityById(Guid id);
        bool DeleteAmenity(Guid id);
    }
}
