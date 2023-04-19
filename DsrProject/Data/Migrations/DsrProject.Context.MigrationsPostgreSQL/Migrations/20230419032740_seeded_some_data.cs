using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DsrProject.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class seeded_some_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "Id", "Name", "Uid" },
                values: new object[] { 1, "Ali", new Guid("cbacb2d5-e62f-45eb-9184-cafae7774404") });

            migrationBuilder.InsertData(
                table: "respondents",
                columns: new[] { "Id", "Email", "Name", "Uid" },
                values: new object[] { 1, "Tom@Talking.ru", "Tom", new Guid("ab32a178-035e-4a04-b875-703d678967fd") });

            migrationBuilder.InsertData(
                table: "authordetails",
                columns: new[] { "Id", "AuthorId", "Country", "Family" },
                values: new object[] { 1, 1, "UZ", "Aliyev" });

            migrationBuilder.InsertData(
                table: "thoughts",
                columns: new[] { "Id", "AuthorId", "Description", "Title", "Uid" },
                values: new object[,]
                {
                    { 1, 1, "Hello world", "Best", new Guid("4216884b-efa7-4c14-888f-f95d5a863a66") },
                    { 2, 1, "Hello programmer", "Worst", new Guid("8afb95cc-1f4b-4ce7-9f01-e3ab8876f4ba") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "authordetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "respondents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "thoughts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "thoughts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
