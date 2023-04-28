using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DsrProject.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class removed_respondent_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_respondents_RespondentId",
                table: "comments");

            migrationBuilder.DropTable(
                name: "thoughts_respondents");

            migrationBuilder.DropTable(
                name: "respondents");

            migrationBuilder.DropIndex(
                name: "IX_comments_RespondentId",
                table: "comments");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "comments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "thoughts_users",
                columns: table => new
                {
                    ThoughtId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thoughts_users", x => new { x.ThoughtId, x.UserId });
                    table.ForeignKey(
                        name: "FK_thoughts_users_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_thoughts_users_thoughts_ThoughtId",
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

            migrationBuilder.CreateIndex(
                name: "IX_comments_UserId",
                table: "comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_thoughts_users_UserId",
                table: "thoughts_users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_AspNetUsers_UserId",
                table: "comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_AspNetUsers_UserId",
                table: "comments");

            migrationBuilder.DropTable(
                name: "thoughts_users");

            migrationBuilder.DropIndex(
                name: "IX_comments_UserId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "comments");

            migrationBuilder.CreateTable(
                name: "respondents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_respondents", x => x.Id);
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

            migrationBuilder.UpdateData(
                table: "authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Uid",
                value: new Guid("cbacb2d5-e62f-45eb-9184-cafae7774404"));

            migrationBuilder.InsertData(
                table: "respondents",
                columns: new[] { "Id", "Email", "Name", "Uid" },
                values: new object[] { 1, "Tom@Talking.ru", "Tom", new Guid("ab32a178-035e-4a04-b875-703d678967fd") });

            migrationBuilder.UpdateData(
                table: "thoughts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Uid",
                value: new Guid("4216884b-efa7-4c14-888f-f95d5a863a66"));

            migrationBuilder.UpdateData(
                table: "thoughts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Uid",
                value: new Guid("8afb95cc-1f4b-4ce7-9f01-e3ab8876f4ba"));

            migrationBuilder.CreateIndex(
                name: "IX_comments_RespondentId",
                table: "comments",
                column: "RespondentId");

            migrationBuilder.CreateIndex(
                name: "IX_respondents_Uid",
                table: "respondents",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_thoughts_respondents_RespondentId",
                table: "thoughts_respondents",
                column: "RespondentId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_respondents_RespondentId",
                table: "comments",
                column: "RespondentId",
                principalTable: "respondents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
