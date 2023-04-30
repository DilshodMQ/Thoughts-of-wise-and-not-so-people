using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DsrProject.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class relationship_changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "thoughts_categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "thoughts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Uid",
                value: new Guid("1a728c73-1c8b-4297-89ec-e514bf050897"));

            migrationBuilder.UpdateData(
                table: "authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Uid",
                value: new Guid("3f19fb2a-a890-4299-84a0-47154b862bd9"));

            migrationBuilder.UpdateData(
                table: "authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Uid",
                value: new Guid("0d0ef11d-5a02-4014-80cb-7973b9ffa000"));

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "AuthorId", "Title", "Uid" },
                values: new object[] { 1, 1, "Philosophy", new Guid("283ccfdd-cf2d-4ff7-8569-1f8e952a0a1b") });

            migrationBuilder.UpdateData(
                table: "thoughts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Uid" },
                values: new object[] { 1, new Guid("2d949017-12ec-4aff-b872-6103e238e19c") });

            migrationBuilder.UpdateData(
                table: "thoughts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "CategoryId", "Uid" },
                values: new object[] { 2, 1, new Guid("a233059e-a9e4-4f5c-aa7f-d2f93032c62e") });

            migrationBuilder.CreateIndex(
                name: "IX_thoughts_CategoryId",
                table: "thoughts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_thoughts_categories_CategoryId",
                table: "thoughts",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_thoughts_categories_CategoryId",
                table: "thoughts");

            migrationBuilder.DropIndex(
                name: "IX_thoughts_CategoryId",
                table: "thoughts");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "thoughts");

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

            migrationBuilder.UpdateData(
                table: "authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Uid",
                value: new Guid("ee102c86-3129-4376-b874-569e8fe7c9e7"));

            migrationBuilder.UpdateData(
                table: "authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Uid",
                value: new Guid("cfc0e9b1-b187-4714-b22e-b7cfd52e32a1"));

            migrationBuilder.UpdateData(
                table: "authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Uid",
                value: new Guid("52c9822b-1ce6-4754-bdc9-389f000c5c14"));

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
                columns: new[] { "AuthorId", "Uid" },
                values: new object[] { 1, new Guid("4b7c2cd1-abb8-48b6-a314-014e1ecd6977") });

            migrationBuilder.CreateIndex(
                name: "IX_thoughts_categories_CategoryId",
                table: "thoughts_categories",
                column: "CategoryId");
        }
    }
}
