using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLagoon.Application.DTOs
{
    public class VillaNumberDto
    {
        [Display(Name = "Villa Number")]
        public int Villa_Number { get; set; }
        [Display(Name = "Villa")]
        public Guid VillaId { get; set; }
        [Display(Name = "Special Details")]
        public string? SpecialDetails { get; set; }
    }
}
