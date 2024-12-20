using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("630214c3-8226-48c7-9e8a-8ebb0b418dc7"), new DateTime(2024, 12, 20, 11, 44, 51, 616, DateTimeKind.Local).AddTicks(3017), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://placehold.co/600x401", "Premium Pool Villa", 4, 300.0, 550, null },
                    { new Guid("7a98337e-cba8-4cbd-b458-e3bf97d592b2"), new DateTime(2024, 12, 20, 11, 44, 51, 616, DateTimeKind.Local).AddTicks(3019), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://placehold.co/600x402", "Luxury Pool Villa", 4, 400.0, 750, null },
                    { new Guid("cda8ea40-5fc7-4a32-a5ed-c9f088141b29"), new DateTime(2024, 12, 20, 11, 44, 51, 616, DateTimeKind.Local).AddTicks(2964), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://placehold.co/600x400", "Royal Villa", 4, 200.0, 550, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("630214c3-8226-48c7-9e8a-8ebb0b418dc7"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("7a98337e-cba8-4cbd-b458-e3bf97d592b2"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("cda8ea40-5fc7-4a32-a5ed-c9f088141b29"));
        }
    }
}
