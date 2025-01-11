using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.DTOs;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Services.Interface
{
    public interface IVillaService
    {
        IEnumerable<Villa> GetAllVillas();
        Villa GetVillaById(Guid id);
        void CreateVilla(CreateVillaDto item);
        void UpdateVilla(UpdateVillaDto item);
        bool DeleteVilla(Guid id);
    }
}
