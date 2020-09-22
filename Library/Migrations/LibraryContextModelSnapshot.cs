﻿// <auto-generated />
using System;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Library.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(30)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Name = "William Shakespeare"
                        },
                        new
                        {
                            ID = -2,
                            Name = "Agatha Christie"
                        },
                        new
                        {
                            ID = -3,
                            Name = "Barbara Cartland"
                        },
                        new
                        {
                            ID = -4,
                            Name = "Danielle Steel"
                        },
                        new
                        {
                            ID = -5,
                            Name = "Harold Robbins"
                        });
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(10)");

                    b.Property<int>("AuthorID")
                        .HasColumnName("author_id")
                        .HasColumnType("int(10)");

                    b.Property<DateTime>("CheckedOutDate")
                        .HasColumnName("checked_out_date")
                        .HasColumnType("date");

                    b.Property<DateTime>("DueDate")
                        .HasColumnName("due_date")
                        .HasColumnType("date");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnName("publication_date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnName("returned_date")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("varchar(30)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID")
                        .HasName("FK_Book_Author");

                    b.ToTable("Book");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            AuthorID = -1,
                            CheckedOutDate = new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 10, 6, 16, 42, 42, 541, DateTimeKind.Local).AddTicks(5920),
                            PublicationDate = new DateTime(1604, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Measure for Measure"
                        },
                        new
                        {
                            ID = -2,
                            AuthorID = -1,
                            CheckedOutDate = new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 9, 29, 16, 42, 42, 541, DateTimeKind.Local).AddTicks(8270),
                            PublicationDate = new DateTime(1602, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Troilus and Cressida"
                        },
                        new
                        {
                            ID = -3,
                            AuthorID = -1,
                            CheckedOutDate = new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 10, 6, 16, 42, 42, 541, DateTimeKind.Local).AddTicks(8277),
                            PublicationDate = new DateTime(1599, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Hamlet"
                        });
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.HasOne("Library.Models.Author", "Authors")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .HasConstraintName("FK_Book_Author")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
