using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedingDataDiaryEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Content", "Created", "Title" },
                values: new object[,]
                {
                    { 1, "Went hiking with Joe!", new DateTime(2024, 8, 5, 11, 2, 22, 493, DateTimeKind.Local).AddTicks(5525), "Went hiking" },
                    { 2, "Went shopping with Joe!", new DateTime(2024, 8, 5, 11, 2, 22, 493, DateTimeKind.Local).AddTicks(5921), "Went shopping" },
                    { 3, "Went diving with Joe!", new DateTime(2024, 8, 5, 11, 2, 22, 493, DateTimeKind.Local).AddTicks(5925), "Went diving" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
