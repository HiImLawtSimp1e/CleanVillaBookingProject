using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAuthIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("0545955d-fd70-45bf-9220-9641e2378437"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("24b3f9f0-f184-423d-9ae6-c2247131f55e"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("2f25775c-b773-4570-9617-06544d279ebc"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("740b18ee-cd55-43d6-96a1-98e41ad7cf70"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("8744551e-3a8d-4dd6-b8d1-449a09a8700d"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("95c6ea25-596d-456a-ae9e-2cb3f8106047"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("9c246920-3da3-4ecf-b2e5-a30b51b27cc0"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("b88ace2e-2235-4969-a858-91f640d11d43"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("d7e62742-ec8d-4d52-abd0-52cf234eae56"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("e8c50b20-6013-4ff7-9557-d7f54f77457e"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("f4ceb631-cded-4516-ac2b-08a479cc42eb"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
        }
    }
}
