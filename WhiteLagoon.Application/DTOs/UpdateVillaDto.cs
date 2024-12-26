using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLagoon.Application.DTOs
{
    public class UpdateVillaDto
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Display(Name = "Price per night")]
        [Range(10, 10000)]
        public double Price { get; set; }
        public int Sqft { get; set; }
        [Range(1, 10)]
        public int Occupancy { get; set; }
        public IFormFile? Image { get; set; }
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
