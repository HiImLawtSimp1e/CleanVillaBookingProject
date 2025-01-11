using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.DTOs;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Services.Interface
{
    public interface IVillaNumberService
    {
        IEnumerable<VillaNumber> GetAllVillaNumbers();
        VillaNumber GetVillaNumberById(int villaNumberId);
        void CreateVillaNumber(VillaNumberDto item);
        void UpdateVillaNumber(VillaNumberDto item);
        bool DeleteVillaNumber(VillaNumberDto item);
        bool CheckVillaNumberExists(int villa_Number);
    }
}
