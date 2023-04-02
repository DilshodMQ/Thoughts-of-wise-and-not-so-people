using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DsrProject.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
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
                name: "authordetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Family = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authordetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_authordetails_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "authors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "thoughts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thoughts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_thoughts_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    RespondentId = table.Column<int>(type: "integer", nullable: false),
                    ThoughtId = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_respondents_RespondentId",
                        column: x => x.RespondentId,
                        principalTable: "respondents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_thoughts_ThoughtId",
                        column: x => x.ThoughtId,
                        principalTable: "thoughts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "thoughts_categories",
                columns: table => new
                {
                    ThoughtId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thoughts_categories", x => new { x.ThoughtId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_thoughts_categories_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_thoughts_categories_thoughts_ThoughtId",
                        column: x => x.ThoughtId,
                        principalTable: "thoughts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "thoughts_respondents",
                columns: table => new
                {
                    ThoughtId = table.Column<int>(type: "integer", nullable: false),
                    RespondentId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thoughts_respondents", x => new { x.ThoughtId, x.RespondentId });
                    table.ForeignKey(
                        name: "FK_thoughts_respondents_respondents_RespondentId",
                        column: x => x.RespondentId,
                        principalTable: "respondents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_thoughts_respondents_thoughts_ThoughtId",
                        column: x => x.ThoughtId,
                        principalTable: "thoughts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_authordetails_AuthorId",
                table: "authordetails",
                column: "AuthorId",
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
                name: "IX_comments_RespondentId",
                table: "comments",
                column: "RespondentId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_ThoughtId",
                table: "comments",
                column: "ThoughtId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_Uid",
                table: "comments",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_respondents_Uid",
                table: "respondents",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_thoughts_AuthorId",
                table: "thoughts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_thoughts_Uid",
                table: "thoughts",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_thoughts_categories_CategoryId",
                table: "thoughts_categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_thoughts_respondents_RespondentId",
                table: "thoughts_respondents",
                column: "RespondentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authordetails");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "thoughts_categories");

            migrationBuilder.DropTable(
                name: "thoughts_respondents");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "respondents");

            migrationBuilder.DropTable(
                name: "thoughts");

            migrationBuilder.DropTable(
                name: "authors");
        }
    }
}
