using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DsrProject.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class added_models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Thoughts",
                table: "Thoughts");

            migrationBuilder.RenameTable(
                name: "Thoughts",
                newName: "thoughts");

            migrationBuilder.RenameIndex(
                name: "IX_Thoughts_Uid",
                table: "thoughts",
                newName: "IX_thoughts_Uid");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "thoughts",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "thoughts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_thoughts",
                table: "thoughts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "author_details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Family = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author_details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "respondents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_respondents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_authors_author_details_Id",
                        column: x => x.Id,
                        principalTable: "author_details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "thoughts_categories",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    ThoughtsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thoughts_categories", x => new { x.CategoriesId, x.ThoughtsId });
                    table.ForeignKey(
                        name: "FK_thoughts_categories_categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_thoughts_categories_thoughts_ThoughtsId",
                        column: x => x.ThoughtsId,
                        principalTable: "thoughts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "respondents_categories",
                columns: table => new
                {
                    RespondentsId = table.Column<int>(type: "integer", nullable: false),
                    ThoughtsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_respondents_categories", x => new { x.RespondentsId, x.ThoughtsId });
                    table.ForeignKey(
                        name: "FK_respondents_categories_respondents_RespondentsId",
                        column: x => x.RespondentsId,
                        principalTable: "respondents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_respondents_categories_thoughts_ThoughtsId",
                        column: x => x.ThoughtsId,
                        principalTable: "thoughts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_thoughts_AuthorId",
                table: "thoughts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_authors_Name",
                table: "authors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_authors_Uid",
                table: "authors",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_categories_Uid",
                table: "categories",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_respondents_Uid",
                table: "respondents",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_respondents_categories_ThoughtsId",
                table: "respondents_categories",
                column: "ThoughtsId");

            migrationBuilder.CreateIndex(
                name: "IX_thoughts_categories_ThoughtsId",
                table: "thoughts_categories",
                column: "ThoughtsId");

            migrationBuilder.AddForeignKey(
                name: "FK_thoughts_authors_AuthorId",
                table: "thoughts",
                column: "AuthorId",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_thoughts_authors_AuthorId",
                table: "thoughts");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "respondents_categories");

            migrationBuilder.DropTable(
                name: "thoughts_categories");

            migrationBuilder.DropTable(
                name: "author_details");

            migrationBuilder.DropTable(
                name: "respondents");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_thoughts",
                table: "thoughts");

            migrationBuilder.DropIndex(
                name: "IX_thoughts_AuthorId",
                table: "thoughts");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "thoughts");

            migrationBuilder.RenameTable(
                name: "thoughts",
                newName: "Thoughts");

            migrationBuilder.RenameIndex(
                name: "IX_thoughts_Uid",
                table: "Thoughts",
                newName: "IX_Thoughts_Uid");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Thoughts",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Thoughts",
                table: "Thoughts",
                column: "Id");
        }
    }
}
