using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITProject.Migrations
{
    public partial class AddAvailableSeats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "Travels",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Travels");

            // migrationBuilder.InsertData(
            //     table: "Cities",
            //     columns: new[] { "Id", "Name" },
            //     values: new object[,]
            //     {
            //         { 1, "Cairo" },
            //         { 2, "Sharqia" },
            //         { 3, "Luxor" },
            //         { 4, "Aswan" },
            //         { 5, "Alexandria" }
            //     });

            // migrationBuilder.InsertData(
            //     table: "Travels",
            //     columns: new[] { "Id", "FromCityId", "StartAt", "Title", "ToCityId" },
            //     values: new object[,]
            //     {
            //         { 1, 1, new DateTime(2021, 6, 4, 14, 29, 58, 199, DateTimeKind.Local).AddTicks(6789), "Travel Cairo to Sharqia", 2 },
            //         { 2, 2, new DateTime(2021, 6, 4, 14, 29, 58, 201, DateTimeKind.Local).AddTicks(3051), "Travel Sharqia to Luxor", 3 },
            //         { 3, 3, new DateTime(2021, 6, 4, 14, 29, 58, 201, DateTimeKind.Local).AddTicks(3070), "Travel Luxor to Aswan", 4 },
            //         { 4, 4, new DateTime(2021, 6, 4, 14, 29, 58, 201, DateTimeKind.Local).AddTicks(3074), "Travel Aswan to Alexandria", 5 },
            //         { 5, 5, new DateTime(2021, 6, 4, 14, 29, 58, 201, DateTimeKind.Local).AddTicks(3076), "Travel Alexandria to Sharqia", 2 }
            //     });
        }
    }
}
