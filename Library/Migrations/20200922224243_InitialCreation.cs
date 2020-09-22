using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    publication_date = table.Column<DateTime>(type: "date", nullable: false),
                    checked_out_date = table.Column<DateTime>(type: "date", nullable: false),
                    due_date = table.Column<DateTime>(type: "date", nullable: false),
                    returned_date = table.Column<DateTime>(type: "date", nullable: true),
                    author_id = table.Column<int>(type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.id);
                    table.ForeignKey(
                        name: "FK_Book_Author",
                        column: x => x.author_id,
                        principalTable: "Author",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { -1, "William Shakespeare" },
                    { -2, "Agatha Christie" },
                    { -3, "Barbara Cartland" },
                    { -4, "Danielle Steel" },
                    { -5, "Harold Robbins" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "id", "author_id", "checked_out_date", "due_date", "publication_date", "returned_date", "title" },
                values: new object[] { -1, -1, new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 6, 16, 42, 42, 541, DateTimeKind.Local).AddTicks(5920), new DateTime(1604, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Measure for Measure" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "id", "author_id", "checked_out_date", "due_date", "publication_date", "returned_date", "title" },
                values: new object[] { -2, -1, new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 29, 16, 42, 42, 541, DateTimeKind.Local).AddTicks(8270), new DateTime(1602, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Troilus and Cressida" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "id", "author_id", "checked_out_date", "due_date", "publication_date", "returned_date", "title" },
                values: new object[] { -3, -1, new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 6, 16, 42, 42, 541, DateTimeKind.Local).AddTicks(8277), new DateTime(1599, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hamlet" });

            migrationBuilder.CreateIndex(
                name: "FK_Book_Author",
                table: "Book",
                column: "author_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
