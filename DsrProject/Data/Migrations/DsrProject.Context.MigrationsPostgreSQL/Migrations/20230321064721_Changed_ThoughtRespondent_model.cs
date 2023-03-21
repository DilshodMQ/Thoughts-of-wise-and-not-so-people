using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DsrProject.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Changed_ThoughtRespondent_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "thoughts_respondents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "Uid",
                table: "thoughts_respondents",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "thoughts_respondents");

            migrationBuilder.DropColumn(
                name: "Uid",
                table: "thoughts_respondents");
        }
    }
}
