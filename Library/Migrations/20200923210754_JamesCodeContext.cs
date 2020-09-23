using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class JamesCodeContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "book");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "author");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "book",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "book",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "returned_date",
                table: "book",
                newName: "ReturnedDate");

            migrationBuilder.RenameColumn(
                name: "publication_date",
                table: "book",
                newName: "PublicationDate");

            migrationBuilder.RenameColumn(
                name: "due_date",
                table: "book",
                newName: "DueDate");

            migrationBuilder.RenameColumn(
                name: "checked_out_date",
                table: "book",
                newName: "CheckedOutDate");

            migrationBuilder.RenameColumn(
                name: "author_id",
                table: "book",
                newName: "AuthorID");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "author",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "author",
                newName: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book",
                table: "book",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_author",
                table: "author",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "author",
                keyColumn: "ID",
                keyValue: -5,
                column: "Name",
                value: "William Shakespeare");

            migrationBuilder.UpdateData(
                table: "author",
                keyColumn: "ID",
                keyValue: -4,
                column: "Name",
                value: "R.L. Stein");

            migrationBuilder.UpdateData(
                table: "author",
                keyColumn: "ID",
                keyValue: -3,
                column: "Name",
                value: "George Orwell");

            migrationBuilder.UpdateData(
                table: "author",
                keyColumn: "ID",
                keyValue: -2,
                column: "Name",
                value: "Terry Pratchet");

            migrationBuilder.UpdateData(
                table: "author",
                keyColumn: "ID",
                keyValue: -1,
                column: "Name",
                value: "Dr. Seuss");

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "ID", "Name" },
                values: new object[] { -6, "H.P. Lovecraft" });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -3,
                columns: new[] { "DueDate", "PublicationDate", "Title" },
                values: new object[] { new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1957, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "How the Grinch Stole Christmas!" });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -2,
                columns: new[] { "DueDate", "PublicationDate", "ReturnedDate", "Title" },
                values: new object[] { new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1957, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Cat in the Hat" });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -1,
                columns: new[] { "DueDate", "PublicationDate", "ReturnedDate", "Title" },
                values: new object[] { new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1960, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Green Eggs and Ham" });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "ID", "AuthorID", "CheckedOutDate", "DueDate", "PublicationDate", "ReturnedDate", "Title" },
                values: new object[,]
                {
                    { -4, -3, new DateTime(2018, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nineteen Eighty-Four" },
                    { -6, -3, new DateTime(2020, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1945, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Animal Farm" },
                    { -7, -5, new DateTime(2020, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1600, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hamlet" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "ID", "AuthorID", "CheckedOutDate", "DueDate", "PublicationDate", "ReturnedDate", "Title" },
                values: new object[] { -5, -6, new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1928, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Call of Cthulhu" });

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author",
                table: "book",
                column: "AuthorID",
                principalTable: "author",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author",
                table: "book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_book",
                table: "book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_author",
                table: "author");

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "ID",
                keyValue: -6);

            migrationBuilder.RenameTable(
                name: "book",
                newName: "Book");

            migrationBuilder.RenameTable(
                name: "author",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Book",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Book",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ReturnedDate",
                table: "Book",
                newName: "returned_date");

            migrationBuilder.RenameColumn(
                name: "PublicationDate",
                table: "Book",
                newName: "publication_date");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "Book",
                newName: "due_date");

            migrationBuilder.RenameColumn(
                name: "CheckedOutDate",
                table: "Book",
                newName: "checked_out_date");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Book",
                newName: "author_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Author",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Author",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "id",
                keyValue: -5,
                column: "name",
                value: "Harold Robbins");

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "id",
                keyValue: -4,
                column: "name",
                value: "Danielle Steel");

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "id",
                keyValue: -3,
                column: "name",
                value: "Barbara Cartland");

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "id",
                keyValue: -2,
                column: "name",
                value: "Agatha Christie");

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "id",
                keyValue: -1,
                column: "name",
                value: "William Shakespeare");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: -3,
                columns: new[] { "due_date", "publication_date", "title" },
                values: new object[] { new DateTime(2020, 10, 6, 16, 42, 42, 541, DateTimeKind.Local).AddTicks(8277), new DateTime(1599, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hamlet" });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: -2,
                columns: new[] { "due_date", "publication_date", "returned_date", "title" },
                values: new object[] { new DateTime(2020, 9, 29, 16, 42, 42, 541, DateTimeKind.Local).AddTicks(8270), new DateTime(1602, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Troilus and Cressida" });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "id",
                keyValue: -1,
                columns: new[] { "due_date", "publication_date", "returned_date", "title" },
                values: new object[] { new DateTime(2020, 10, 6, 16, 42, 42, 541, DateTimeKind.Local).AddTicks(5920), new DateTime(1604, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Measure for Measure" });

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author",
                table: "Book",
                column: "author_id",
                principalTable: "Author",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
