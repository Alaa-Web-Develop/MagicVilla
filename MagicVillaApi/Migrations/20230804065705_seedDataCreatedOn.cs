using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVillaApi.Migrations
{
    /// <inheritdoc />
    public partial class seedDataCreatedOn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 9, 57, 5, 13, DateTimeKind.Local).AddTicks(8638));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 9, 57, 5, 13, DateTimeKind.Local).AddTicks(8645));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 9, 57, 5, 13, DateTimeKind.Local).AddTicks(8652));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 9, 56, 8, 867, DateTimeKind.Local).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 9, 56, 8, 867, DateTimeKind.Local).AddTicks(4990));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 9, 56, 8, 867, DateTimeKind.Local).AddTicks(4994));
        }
    }
}
