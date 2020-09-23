﻿// <auto-generated />
using System;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20200923212723_ExtensionCountSeedData")]
    partial class ExtensionCountSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Library.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(30)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.ToTable("author");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Name = "Dr. Seuss"
                        },
                        new
                        {
                            ID = -2,
                            Name = "Terry Pratchet"
                        },
                        new
                        {
                            ID = -3,
                            Name = "George Orwell"
                        },
                        new
                        {
                            ID = -4,
                            Name = "R.L. Stein"
                        },
                        new
                        {
                            ID = -5,
                            Name = "William Shakespeare"
                        },
                        new
                        {
                            ID = -6,
                            Name = "H.P. Lovecraft"
                        });
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int(10)");

                    b.Property<int>("AuthorID")
                        .HasColumnName("AuthorID")
                        .HasColumnType("int(10)");

                    b.Property<DateTime>("CheckedOutDate")
                        .HasColumnName("CheckedOutDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("DueDate")
                        .HasColumnName("DueDate")
                        .HasColumnType("date");

                    b.Property<int>("ExtensionCount")
                        .HasColumnName("ExtensionCount")
                        .HasColumnType("int(10)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnName("PublicationDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnName("ReturnedDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("Title")
                        .HasColumnType("varchar(30)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID")
                        .HasName("FK_Book_Author");

                    b.ToTable("book");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            AuthorID = -1,
                            CheckedOutDate = new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExtensionCount = 0,
                            PublicationDate = new DateTime(1960, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnedDate = new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Green Eggs and Ham"
                        },
                        new
                        {
                            ID = -2,
                            AuthorID = -1,
                            CheckedOutDate = new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExtensionCount = 0,
                            PublicationDate = new DateTime(1957, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnedDate = new DateTime(2020, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Cat in the Hat"
                        },
                        new
                        {
                            ID = -3,
                            AuthorID = -1,
                            CheckedOutDate = new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExtensionCount = 0,
                            PublicationDate = new DateTime(1957, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "How the Grinch Stole Christmas!"
                        },
                        new
                        {
                            ID = -4,
                            AuthorID = -3,
                            CheckedOutDate = new DateTime(2018, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExtensionCount = 0,
                            PublicationDate = new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnedDate = new DateTime(2018, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Nineteen Eighty-Four"
                        },
                        new
                        {
                            ID = -5,
                            AuthorID = -6,
                            CheckedOutDate = new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExtensionCount = 0,
                            PublicationDate = new DateTime(1928, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnedDate = new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Call of Cthulhu"
                        },
                        new
                        {
                            ID = -6,
                            AuthorID = -3,
                            CheckedOutDate = new DateTime(2020, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExtensionCount = 0,
                            PublicationDate = new DateTime(1945, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnedDate = new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Animal Farm"
                        },
                        new
                        {
                            ID = -7,
                            AuthorID = -5,
                            CheckedOutDate = new DateTime(2020, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExtensionCount = 0,
                            PublicationDate = new DateTime(1600, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Hamlet"
                        });
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.HasOne("Library.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .HasConstraintName("FK_Book_Author")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
