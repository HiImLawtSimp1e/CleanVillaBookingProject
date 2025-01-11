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
    public class VillaNumberService : IVillaNumberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VillaNumberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateVillaNumber(VillaNumberDto item)
        {
            var newVillaNumber = new VillaNumber
            {
                Villa_Number = item.Villa_Number,
                VillaId = item.VillaId,
                SpecialDetails = item.SpecialDetails
            };

            _unitOfWork.VillaNumber.Add(newVillaNumber);
            _unitOfWork.Save();
        }

        public bool DeleteVillaNumber(VillaNumberDto item)
        {
            var villaNumber = _unitOfWork.VillaNumber.Get(vn => vn.Villa_Number == item.Villa_Number);
            if (villaNumber == null)
            {
                return false;
            }

            _unitOfWork.VillaNumber.Remove(villaNumber);
            _unitOfWork.Save();

            return true;
        }

        public IEnumerable<VillaNumber> GetAllVillaNumbers()
        {
            var villaNumbers = _unitOfWork.VillaNumber.GetAll(includeProperties: "Villa");

            return villaNumbers;
        }

        public VillaNumber GetVillaNumberById(int villaNumberId)
        {
            var villaNumber = _unitOfWork.VillaNumber.Get(v => v.Villa_Number == villaNumberId, includeProperties: "Villa");

            return villaNumber;
        }

        public void UpdateVillaNumber(VillaNumberDto item)
        {
            var villaNumber = _unitOfWork.VillaNumber.Get(vn => vn.Villa_Number == item.Villa_Number);

            villaNumber.VillaId = item.VillaId;
            villaNumber.SpecialDetails = item.SpecialDetails;

            _unitOfWork.VillaNumber.Update(villaNumber);
            _unitOfWork.Save();
        }

        public bool CheckVillaNumberExists(int villa_Number)
        {
            return _unitOfWork.VillaNumber.Any(u => u.Villa_Number == villa_Number);
        }
    }
}
