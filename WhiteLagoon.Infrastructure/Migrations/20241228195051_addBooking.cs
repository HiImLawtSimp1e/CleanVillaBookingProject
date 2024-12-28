using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("0445c164-6534-44e3-8e2a-bb07ecf2d6e2"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("053b8cee-69ab-411b-938f-00d17f84b075"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("1291dddb-7ccb-4746-8864-8532bce246a9"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("25520af0-5e1a-4987-aec7-808174f074d3"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("36d1a049-69a8-45e1-a36f-c6bdceb31ec5"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("401d1f6c-256a-427d-934a-cd332619e49d"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("777d35a1-25e9-4153-9f15-b22f1334d6ee"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("a539cea1-5bf4-41bf-b69c-1303c1fd7f11"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("c3585395-5d40-4d71-bdc2-cd911c1efeea"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("c8d5e014-7f65-4df2-9272-3108ef0f6cc1"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("e5b4c4d9-fb55-4099-aead-9e513700721f"));

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VillaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    Nights = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckInDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CheckOutDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsPaymentSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StripeSessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StripePaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualCheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualCheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VillaNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Villas_VillaId",
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
                    { new Guid("291bfe85-44df-45e2-b870-bbcc3eb7f101"), null, "1 king bed and 1 sofa bed", new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e") },
                    { new Guid("3a67d691-f7cd-4c9e-af5e-d5bfbf188766"), null, "Jacuzzi", new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a") },
                    { new Guid("4c054e29-f099-4a03-8811-4e326f24d01c"), null, "Private Balcony", new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e") },
                    { new Guid("7a3c285a-b2da-49a7-822b-45b11bc70b11"), null, "Private Balcony", new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae") },
                    { new Guid("8dbcf618-a23f-4cf0-a3f9-b3a62bff30cd"), null, "king bed or 2 double beds", new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae") },
                    { new Guid("9536c793-f4a6-4e63-a28e-c1df6d2abaac"), null, "Private Plunge Pool", new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae") },
                    { new Guid("aa355bf4-028b-4af0-bf07-1617fa6f3c68"), null, "Microwave", new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e") },
                    { new Guid("ad584f3a-89f2-4161-8b3c-caf917fc02b2"), null, "Private Pool", new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a") },
                    { new Guid("c424c45f-9088-44d5-b10c-ea4a1c44f45a"), null, "Private Pool", new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e") },
                    { new Guid("ccb8692f-b5b6-4729-bffa-05bfce02f508"), null, "Microwave and Mini Refrigerator", new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae") },
                    { new Guid("d9272cd2-f9e3-4106-b459-fb9f32d75084"), null, "Private Balcony", new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a") }
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 29, 2, 50, 47, 597, DateTimeKind.Local).AddTicks(1944));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 29, 2, 50, 47, 597, DateTimeKind.Local).AddTicks(1980));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 29, 2, 50, 47, 597, DateTimeKind.Local).AddTicks(1977));

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VillaId",
                table: "Bookings",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("291bfe85-44df-45e2-b870-bbcc3eb7f101"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("3a67d691-f7cd-4c9e-af5e-d5bfbf188766"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("4c054e29-f099-4a03-8811-4e326f24d01c"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("7a3c285a-b2da-49a7-822b-45b11bc70b11"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("8dbcf618-a23f-4cf0-a3f9-b3a62bff30cd"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("9536c793-f4a6-4e63-a28e-c1df6d2abaac"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("aa355bf4-028b-4af0-bf07-1617fa6f3c68"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("ad584f3a-89f2-4161-8b3c-caf917fc02b2"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("c424c45f-9088-44d5-b10c-ea4a1c44f45a"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("ccb8692f-b5b6-4729-bffa-05bfce02f508"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("d9272cd2-f9e3-4106-b459-fb9f32d75084"));

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Description", "Name", "VillaId" },
                values: new object[,]
                {
                    { new Guid("0445c164-6534-44e3-8e2a-bb07ecf2d6e2"), null, "Jacuzzi", new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a") },
                    { new Guid("053b8cee-69ab-411b-938f-00d17f84b075"), null, "Private Pool", new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e") },
                    { new Guid("1291dddb-7ccb-4746-8864-8532bce246a9"), null, "Private Balcony", new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e") },
                    { new Guid("25520af0-5e1a-4987-aec7-808174f074d3"), null, "Private Balcony", new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae") },
                    { new Guid("36d1a049-69a8-45e1-a36f-c6bdceb31ec5"), null, "Microwave", new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e") },
                    { new Guid("401d1f6c-256a-427d-934a-cd332619e49d"), null, "Microwave and Mini Refrigerator", new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae") },
                    { new Guid("777d35a1-25e9-4153-9f15-b22f1334d6ee"), null, "Private Balcony", new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a") },
                    { new Guid("a539cea1-5bf4-41bf-b69c-1303c1fd7f11"), null, "1 king bed and 1 sofa bed", new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e") },
                    { new Guid("c3585395-5d40-4d71-bdc2-cd911c1efeea"), null, "Private Plunge Pool", new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae") },
                    { new Guid("c8d5e014-7f65-4df2-9272-3108ef0f6cc1"), null, "Private Pool", new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a") },
                    { new Guid("e5b4c4d9-fb55-4099-aead-9e513700721f"), null, "king bed or 2 double beds", new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae") }
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("22c2f426-2256-4db1-b5b9-881f13b91b7e"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 57, 47, 41, DateTimeKind.Local).AddTicks(1063));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("4e93d429-8b79-4313-91e9-0a2b9c2c5d6a"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 57, 47, 41, DateTimeKind.Local).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("6b359322-86e1-43c4-9eac-57bf9054d1ae"),
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 57, 47, 41, DateTimeKind.Local).AddTicks(1105));
        }
    }
}
