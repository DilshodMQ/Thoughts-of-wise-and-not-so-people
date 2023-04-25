using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DsrProject.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class comment_model_changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RespondentId",
                table: "comments");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RespondentId",
                table: "comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Uid",
                value: new Guid("324b2e20-5174-4e82-b712-7cf4de9f27b7"));

            migrationBuilder.UpdateData(
                table: "thoughts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Uid",
                value: new Guid("68cd6f73-8a9b-48e8-904b-f3e8edc40ad6"));

            migrationBuilder.UpdateData(
                table: "thoughts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Uid",
                value: new Guid("eb228b59-e4dd-410e-ae63-f627ca2c5074"));
        }
    }
}
