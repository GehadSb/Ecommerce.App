using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedingMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "CinemaId", "Description", "EndDate", "MovieCategoryId", "MovieName", "MovieStatusId", "Price", "StartDate" },
                values: new object[,]
                {
                    { 1L, 1L, "dramic movie", new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "After Ever Happy", 1, 150m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 1L, "dramic movie", new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "The Land", 1, 150m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, 1L, "Action movie", new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "The North Man", 1, 150m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, 1L, "dramic movie", new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Brave Heart", 2, 150m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, 1L, "dramic movie", new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luck", 1, 150m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, 2L, "Comedy movie", new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Wrath Of Man", 1, 150m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, 1L, "dramic movie", new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Flight", 1, 150m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, 2L, "Comedy movie", new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "The Last Wish", 2, 150m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, 1L, "Romantic movie", new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Pocahontas", 1, 150m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, 1L, "Horror movie", new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "The Invitation", 1, 150m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, 1L, "Romantic movie", new DateTime(1, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Cinderella", 1, 150m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 11L);
        }
    }
}
