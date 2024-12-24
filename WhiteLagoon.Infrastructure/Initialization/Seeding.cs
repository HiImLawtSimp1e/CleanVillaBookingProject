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
                   Id = new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e"),
                   Name = "Royal Villa",
                   Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                   ImageUrl = "https://placehold.co/600x400",
                   Occupancy = 4,
                   Price = 200,
                   Sqft = 550,
               },
               new Villa
               {
                   Id = new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae"),
                   Name = "Premium Pool Villa",
                   Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                   ImageUrl = "https://placehold.co/600x401",
                   Occupancy = 4,
                   Price = 300,
                   Sqft = 550,
               },
               new Villa
               {
                   Id = new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a"),
                   Name = "Luxury Pool Villa",
                   Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                   ImageUrl = "https://placehold.co/600x402",
                   Occupancy = 4,
                   Price = 400,
                   Sqft = 750,
               });
            builder.Entity<VillaNumber>().HasData(
                new VillaNumber
                {
                    Villa_Number = 101,
                    VillaId = new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e"),
                },
                new VillaNumber
                {
                    Villa_Number = 102,
                    VillaId = new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e"),
                },
                new VillaNumber
                {
                    Villa_Number = 103,
                    VillaId = new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e"),
                },
                new VillaNumber
                {
                    Villa_Number = 104,
                    VillaId = new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e"),
                },
                new VillaNumber
                {
                    Villa_Number = 201,
                    VillaId = new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae"),
                },
                new VillaNumber
                {
                    Villa_Number = 202,
                    VillaId = new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae"),
                },
                new VillaNumber
                {
                    Villa_Number = 203,
                    VillaId = new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae"),
                },
                new VillaNumber
                {
                    Villa_Number = 301,
                    VillaId = new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a"),
                },
                new VillaNumber
                {
                    Villa_Number = 302,
                    VillaId = new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a"),
                });
        }
    }
}
