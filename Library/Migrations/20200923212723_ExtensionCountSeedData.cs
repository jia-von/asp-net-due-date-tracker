using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class ExtensionCountSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExtensionCount",
                table: "book",
                type: "int(10)",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtensionCount",
                table: "book");
        }
    }
}
