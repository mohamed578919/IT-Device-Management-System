using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ListDevice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "InputType", "PropertyName" },
                values: new object[,]
                {
                    { 1, "text", "HD" },
                    { 2, "text", "Processor" },
                    { 3, "text", "Dimensions" },
                    { 4, "text", "MAC Address" },
                    { 5, "text", "IP Address" },
                    { 6, "checkbox", "Allow USB" },
                    { 7, "lookup", "Current User" },
                    { 8, "text", "Network Speed" },
                    { 9, "text", "Operating System" },
                    { 10, "number", "Ports" },
                    { 11, "checkbox", "Is Color" },
                    { 12, "text", "Brand" },
                    { 13, "text", "RAM" },
                    { 14, "text", "Display" },
                    { 15, "text", "X…" },
                    { 16, "text", "Y…" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Department", "FullName" },
                values: new object[,]
                {
                    { 1, "IT", "Mohamed Mostafa" },
                    { 2, "HR", "Sara Ali" },
                    { 3, "Finance", "Omar Hassan" },
                    { 4, "Marketing", "Nada Ibrahim" },
                    { 5, "Operations", "Ahmed Youssef" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Laptop" },
                    { 2, "Desktop" },
                    { 3, "Printer" },
                    { 4, "Switch" },
                    { 5, "screen" }
                });

            migrationBuilder.InsertData(
                table: "CategoryProperties",
                columns: new[] { "CategoryId", "PropertyId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 5 },
                    { 1, 7 },
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 14 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 5 },
                    { 2, 7 },
                    { 2, 12 },
                    { 2, 13 },
                    { 2, 14 },
                    { 3, 5 },
                    { 3, 11 },
                    { 3, 12 },
                    { 4, 5 },
                    { 4, 8 },
                    { 4, 10 },
                    { 4, 12 },
                    { 4, 15 },
                    { 4, 16 },
                    { 5, 12 },
                    { 5, 15 },
                    { 5, 16 }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "AcquisitionDate", "CategoryId", "CurrentUserId", "DeviceName", "Memo", "PropertiesJson", "SerialNo" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "HP LaserJet Pro", "Office Printer", "{\"IP Address\":\"192.168.1.25\",\"Is Color\":\"True\",\"Brand\":\"HP\"}", "PR-12345" },
                    { 2, new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "Dell Latitude", "For IT Department", "{\"Processor\":\"Intel Core i7\",\"HD\":\"512GB SSD\",\"RAM\":\"16GB\",\"Display\":\"15.6 inch\",\"IP Address\":\"192.168.1.50\",\"Brand\":\"Dell\",\"Current User\":\"1\"}", "LT-67890" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 3, 11 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 4, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 5, 12 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryProperties",
                keyColumns: new[] { "CategoryId", "PropertyId" },
                keyValues: new object[] { 5, 16 });

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
