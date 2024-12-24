using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addVillaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    Villa_Number = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.Villa_Number);
                    table.ForeignKey(
                        name: "FK_VillaNumbers_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e"), new DateTime(2024, 12, 24, 21, 7, 25, 99, DateTimeKind.Local).AddTicks(444), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://placehold.co/600x400", "Royal Villa", 4, 200.0, 550, null },
                    { new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a"), new DateTime(2024, 12, 24, 21, 7, 25, 99, DateTimeKind.Local).AddTicks(476), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://placehold.co/600x402", "Luxury Pool Villa", 4, 400.0, 750, null },
                    { new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae"), new DateTime(2024, 12, 24, 21, 7, 25, 99, DateTimeKind.Local).AddTicks(472), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://placehold.co/600x401", "Premium Pool Villa", 4, 300.0, 550, null }
                });

            migrationBuilder.InsertData(
                table: "VillaNumbers",
                columns: new[] { "Villa_Number", "SpecialDetails", "VillaId" },
                values: new object[,]
                {
                    { 101, null, new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e") },
                    { 102, null, new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e") },
                    { 103, null, new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e") },
                    { 104, null, new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e") },
                    { 201, null, new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae") },
                    { 202, null, new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae") },
                    { 203, null, new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae") },
                    { 301, null, new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a") },
                    { 302, null, new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae"));

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
    }
}
