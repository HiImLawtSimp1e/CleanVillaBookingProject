using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAmenity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenities_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Description", "Name", "VillaId" },
                values: new object[,]
                {
                    { new Guid("0545955d-fd70-45bf-9220-9641e2378437"), null, "1 king bed and 1 sofa bed", new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e") },
                    { new Guid("24b3f9f0-f184-423d-9ae6-c2247131f55e"), null, "Microwave", new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e") },
                    { new Guid("2f25775c-b773-4570-9617-06544d279ebc"), null, "Private Plunge Pool", new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae") },
                    { new Guid("740b18ee-cd55-43d6-96a1-98e41ad7cf70"), null, "Private Balcony", new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a") },
                    { new Guid("8744551e-3a8d-4dd6-b8d1-449a09a8700d"), null, "Microwave and Mini Refrigerator", new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae") },
                    { new Guid("95c6ea25-596d-456a-ae9e-2cb3f8106047"), null, "Private Balcony", new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae") },
                    { new Guid("9c246920-3da3-4ecf-b2e5-a30b51b27cc0"), null, "Jacuzzi", new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a") },
                    { new Guid("b88ace2e-2235-4969-a858-91f640d11d43"), null, "Private Balcony", new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e") },
                    { new Guid("d7e62742-ec8d-4d52-abd0-52cf234eae56"), null, "Private Pool", new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e") },
                    { new Guid("e8c50b20-6013-4ff7-9557-d7f54f77457e"), null, "Private Pool", new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a") },
                    { new Guid("f4ceb631-cded-4516-ac2b-08a479cc42eb"), null, "king bed or 2 double beds", new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae") }
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 1, 45, 21, 229, DateTimeKind.Local).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 1, 45, 21, 229, DateTimeKind.Local).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 1, 45, 21, 229, DateTimeKind.Local).AddTicks(6179));

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_VillaId",
                table: "Amenities",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 24, 21, 7, 25, 99, DateTimeKind.Local).AddTicks(444));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 24, 21, 7, 25, 99, DateTimeKind.Local).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 24, 21, 7, 25, 99, DateTimeKind.Local).AddTicks(472));
        }
    }
}
