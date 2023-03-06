using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DsrProject.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Thought_Model_changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authors_author_details_Id",
                table: "authors");

            migrationBuilder.DropForeignKey(
                name: "FK_thoughts_authors_AuthorId",
                table: "thoughts");

            migrationBuilder.DropForeignKey(
                name: "FK_thoughts_categories_categories_CategoriesId",
                table: "thoughts_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_thoughts_categories_thoughts_ThoughtsId",
                table: "thoughts_categories");

            migrationBuilder.DropTable(
                name: "respondents_categories");

            migrationBuilder.DropIndex(
                name: "IX_authors_Name",
                table: "authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_author_details",
                table: "author_details");

            migrationBuilder.RenameTable(
                name: "author_details",
                newName: "authordetails");

            migrationBuilder.RenameColumn(
                name: "ThoughtsId",
                table: "thoughts_categories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "thoughts_categories",
                newName: "ThoughtId");

            migrationBuilder.RenameIndex(
                name: "IX_thoughts_categories_ThoughtsId",
                table: "thoughts_categories",
                newName: "IX_thoughts_categories_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "ThoughtId",
                table: "thoughts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RespondentId",
                table: "respondents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "authors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "authordetails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_authordetails",
                table: "authordetails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "thoughts_respondents",
                columns: table => new
                {
                    ThoughtId = table.Column<int>(type: "integer", nullable: false),
                    RespondentId = table.Column<int>(type: "integer", nullable: false)
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
                name: "IX_thoughts_respondents_RespondentId",
                table: "thoughts_respondents",
                column: "RespondentId");

            migrationBuilder.AddForeignKey(
                name: "FK_authordetails_authors_Id",
                table: "authordetails",
                column: "Id",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_thoughts_authors_AuthorId",
                table: "thoughts",
                column: "AuthorId",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_thoughts_categories_categories_CategoryId",
                table: "thoughts_categories",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_thoughts_categories_thoughts_ThoughtId",
                table: "thoughts_categories",
                column: "ThoughtId",
                principalTable: "thoughts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authordetails_authors_Id",
                table: "authordetails");

            migrationBuilder.DropForeignKey(
                name: "FK_thoughts_authors_AuthorId",
                table: "thoughts");

            migrationBuilder.DropForeignKey(
                name: "FK_thoughts_categories_categories_CategoryId",
                table: "thoughts_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_thoughts_categories_thoughts_ThoughtId",
                table: "thoughts_categories");

            migrationBuilder.DropTable(
                name: "thoughts_respondents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_authordetails",
                table: "authordetails");

            migrationBuilder.DropColumn(
                name: "ThoughtId",
                table: "thoughts");

            migrationBuilder.DropColumn(
                name: "RespondentId",
                table: "respondents");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "categories");

            migrationBuilder.RenameTable(
                name: "authordetails",
                newName: "author_details");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "thoughts_categories",
                newName: "ThoughtsId");

            migrationBuilder.RenameColumn(
                name: "ThoughtId",
                table: "thoughts_categories",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_thoughts_categories_CategoryId",
                table: "thoughts_categories",
                newName: "IX_thoughts_categories_ThoughtsId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "authors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "author_details",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_author_details",
                table: "author_details",
                column: "Id");

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
                name: "IX_authors_Name",
                table: "authors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_respondents_categories_ThoughtsId",
                table: "respondents_categories",
                column: "ThoughtsId");

            migrationBuilder.AddForeignKey(
                name: "FK_authors_author_details_Id",
                table: "authors",
                column: "Id",
                principalTable: "author_details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_thoughts_authors_AuthorId",
                table: "thoughts",
                column: "AuthorId",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_thoughts_categories_categories_CategoriesId",
                table: "thoughts_categories",
                column: "CategoriesId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_thoughts_categories_thoughts_ThoughtsId",
                table: "thoughts_categories",
                column: "ThoughtsId",
                principalTable: "thoughts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
