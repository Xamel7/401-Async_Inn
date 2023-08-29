using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab12.Migrations
{
    /// <inheritdoc />
    public partial class IdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenity",
                table: "RoomAmenity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRoom",
                table: "HotelRoom");

            migrationBuilder.DeleteData(
                table: "Amenity",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomAmenity",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "RoomAmenity",
                newName: "RoomAmenities");

            migrationBuilder.RenameTable(
                name: "HotelRoom",
                newName: "HotelRooms");

            migrationBuilder.AddColumn<int>(
                name: "HotelID1",
                table: "HotelRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "HotelRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms",
                column: "ID");

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
                name: "HotelAmenity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelAmenity", x => x.Id);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_AmenityID",
                table: "RoomAmenities",
                column: "AmenityID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_RoomID",
                table: "RoomAmenities",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_HotelID",
                table: "HotelRooms",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_HotelID1",
                table: "HotelRooms",
                column: "HotelID1");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_RoomID",
                table: "HotelRooms",
                column: "RoomID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_HotelAmenity_HotelID",
                table: "HotelRooms",
                column: "HotelID",
                principalTable: "HotelAmenity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Hotel_HotelID1",
                table: "HotelRooms",
                column: "HotelID1",
                principalTable: "Hotel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Room_RoomID",
                table: "HotelRooms",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Amenity_AmenityID",
                table: "RoomAmenities",
                column: "AmenityID",
                principalTable: "Amenity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Room_RoomID",
                table: "RoomAmenities",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_HotelAmenity_HotelID",
                table: "HotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Hotel_HotelID1",
                table: "HotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Room_RoomID",
                table: "HotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Amenity_AmenityID",
                table: "RoomAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Room_RoomID",
                table: "RoomAmenities");

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
                name: "HotelAmenity");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenities_AmenityID",
                table: "RoomAmenities");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenities_RoomID",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms");

            migrationBuilder.DropIndex(
                name: "IX_HotelRooms_HotelID",
                table: "HotelRooms");

            migrationBuilder.DropIndex(
                name: "IX_HotelRooms_HotelID1",
                table: "HotelRooms");

            migrationBuilder.DropIndex(
                name: "IX_HotelRooms_RoomID",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "HotelID1",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "HotelRooms");

            migrationBuilder.RenameTable(
                name: "RoomAmenities",
                newName: "RoomAmenity");

            migrationBuilder.RenameTable(
                name: "HotelRooms",
                newName: "HotelRoom");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenity",
                table: "RoomAmenity",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRoom",
                table: "HotelRoom",
                column: "ID");

            migrationBuilder.InsertData(
                table: "Amenity",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "A/C" });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "ID", "Address", "City", "Name", "Phone", "State" },
                values: new object[] { 1, "123 Sesame St", "Memphis", "Elmo's Hotel", "555-555-5555", "TN" });

            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "ID", "HotelID", "Price", "RoomID" },
                values: new object[] { 1, 1, 100.98999999999999, 1 });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "ID", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Basic Room" },
                    { 2, 1, "Basic Single Room" },
                    { 3, 2, "Basic Double Room" }
                });

            migrationBuilder.InsertData(
                table: "RoomAmenity",
                columns: new[] { "ID", "AmenityID", "RoomID" },
                values: new object[] { 1, 1, 1 });
        }
    }
}
