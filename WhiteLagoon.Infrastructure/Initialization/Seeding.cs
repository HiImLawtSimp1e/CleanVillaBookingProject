using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Initialization
{
    public class Seeding
    {
        public static void SeedingData(ModelBuilder builder)
        {
            builder.Entity<Villa>().HasData(
               new Villa
               {
                   Id = Guid.NewGuid(),
                   Name = "Royal Villa",
                   Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                   ImageUrl = "https://placehold.co/600x400",
                   Occupancy = 4,
                   Price = 200,
                   Sqft = 550,
               },
               new Villa
               {
                   Id = Guid.NewGuid(),
                   Name = "Premium Pool Villa",
                   Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                   ImageUrl = "https://placehold.co/600x401",
                   Occupancy = 4,
                   Price = 300,
                   Sqft = 550,
               },
               new Villa
               {
                   Id = Guid.NewGuid(),
                   Name = "Luxury Pool Villa",
                   Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                   ImageUrl = "https://placehold.co/600x402",
                   Occupancy = 4,
                   Price = 400,
                   Sqft = 750,
               });
        }
    }
}
