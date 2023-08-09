using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVillaApi.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "LastUpdatedOn", "Name", "Occupancy", "Rate", "sqfet" },
                values: new object[,]
                {
                    { 1, "Amenity1", new DateTime(2023, 8, 4, 9, 56, 8, 867, DateTimeKind.Local).AddTicks(4908), "Deatils1", "img1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Villa1", 1, 1.0, 1 },
                    { 2, "Amenity2", new DateTime(2023, 8, 4, 9, 56, 8, 867, DateTimeKind.Local).AddTicks(4990), "Deatils2", "img2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Villa2", 2, 2.0, 2 },
                    { 3, "Amenity3", new DateTime(2023, 8, 4, 9, 56, 8, 867, DateTimeKind.Local).AddTicks(4994), "Deatils3", "img3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Villa3", 3, 3.0, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
