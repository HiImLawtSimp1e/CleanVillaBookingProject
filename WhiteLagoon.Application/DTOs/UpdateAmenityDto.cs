using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLagoon.Application.DTOs
{
    public class UpdateAmenityDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid VillaId { get; set; }
    }
}
