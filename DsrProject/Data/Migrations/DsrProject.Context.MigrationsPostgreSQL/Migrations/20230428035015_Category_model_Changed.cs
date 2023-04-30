using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DsrProject.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Category_model_Changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Uid",
                value: new Guid("ee102c86-3129-4376-b874-569e8fe7c9e7"));

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "Id", "Name", "Uid" },
                values: new object[,]
                {
                    { 2, "Arestotel", new Guid("cfc0e9b1-b187-4714-b22e-b7cfd52e32a1") },
                    { 3, "Pifagor", new Guid("52c9822b-1ce6-4754-bdc9-389f000c5c14") }
                });

            migrationBuilder.UpdateData(
                table: "thoughts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Uid",
                value: new Guid("48095cfa-44af-4150-8d59-9deac68a9481"));

            migrationBuilder.UpdateData(
                table: "thoughts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Uid",
                value: new Guid("4b7c2cd1-abb8-48b6-a314-014e1ecd6977"));

            migrationBuilder.CreateIndex(
                name: "IX_categories_AuthorId",
                table: "categories",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_authors_AuthorId",
                table: "categories",
                column: "AuthorId",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_authors_AuthorId",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_categories_AuthorId",
                table: "categories");

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "categories");

            migrationBuilder.UpdateData(
                table: "authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Uid",
                value: new Guid("c6448467-dbb4-474b-9cea-b3b4cbdfae25"));

            migrationBuilder.UpdateData(
                table: "thoughts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Uid",
                value: new Guid("3d8954ab-99d2-4ba9-bb93-6311c13336ff"));

            migrationBuilder.UpdateData(
                table: "thoughts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Uid",
                value: new Guid("72b804fc-c88d-49d8-9815-8e4fbe99192b"));
        }
    }
}
