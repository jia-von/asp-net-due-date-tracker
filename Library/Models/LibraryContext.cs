using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=mvc_library", x => x.ServerVersion("10.4.14-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Name)
                        .HasCharSet("utf8mb4")
                        .HasCollation("utf8mb4_general_ci");

                entity.HasData(
                new Author()
                {
                    ID = -1,
                    Name = "Dr. Seuss"
                },
                new Author()
                {
                    ID = -2,
                    Name = "Terry Pratchet"
                },
                new Author()
                {
                    ID = -3,
                    Name = "George Orwell"
                },
                new Author()
                {
                    ID = -4,
                    Name = "R.L. Stein"
                },
                new Author()
                {
                    ID = -5,
                    Name = "William Shakespeare"
                },
                new Author()
                {
                    ID = -6,
                    Name = "H.P. Lovecraft"
                }
                );
            });

            modelBuilder.Entity<Book>(entity =>
            {

                // Any "string" types should have collation defined.
                // Numeric types such as ints and dates do not.
                entity.Property(e => e.Title)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.AuthorID)
                    .HasName("FK_" + nameof(Book) + "_" + nameof(Author));

                // Always in the one with the foreign key.
                entity.HasOne(child => child.Author)
                    .WithMany(parent => parent.Books)
                    .HasForeignKey(child => child.AuthorID)
                    // When we delete a record, we can modify the behaviour of the case where there are child records.
                    // Restrict: Throw an exception if we try to orphan a child record.
                    // Cascade: Remove any child records that would be orphaned by a removed parent.
                    // SetNull: Set the foreign key field to null on any orphaned child records.
                    // NoAction: Don't commit any deletions of parents which would orphan a child.
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_" + nameof(Book) + "_" + nameof(Author));

                /*
                All three books must have a “CheckoutDate” equal to December 25, 2019.
                One book must be returned on-time with no extension.
                One book must be returned on-time with one extension.
                One book must not have been returned at all!
                */
                entity.HasData(
                    new Book()
                    {
                        ID = -1,
                        Title = "Green Eggs and Ham",
                        AuthorID = -1,
                        CheckedOutDate = new DateTime(2019, 12, 25),
                        PublicationDate = new DateTime(1960, 08, 12),
                        DueDate = new DateTime(2019, 12, 25).AddDays(14),
                        ReturnedDate = new DateTime(2020, 01, 02),
                        ExtensionCount = 0
                    },
                    new Book()
                    {
                        ID = -2,
                        Title = "The Cat in the Hat",
                        AuthorID = -1,
                        CheckedOutDate = new DateTime(2019, 12, 25),
                        PublicationDate = new DateTime(1957, 03, 12),
                        DueDate = new DateTime(2019, 12, 25).AddDays(14).AddDays(7),
                        ReturnedDate = new DateTime(2019, 12, 25).AddDays(14).AddDays(4),
                        ExtensionCount = 0
                    },
                    new Book()
                    {
                        ID = -3,
                        Title = "How the Grinch Stole Christmas!",
                        AuthorID = -1,
                        CheckedOutDate = new DateTime(2019, 12, 25),
                        PublicationDate = new DateTime(1957, 10, 12),
                        DueDate = new DateTime(2019, 12, 25).AddDays(14),
                        ReturnedDate = null,
                        ExtensionCount = 0
                    },
                    new Book()
                    {
                        ID = -4,
                        Title = "Nineteen Eighty-Four",
                        AuthorID = -3,
                        CheckedOutDate = new DateTime(2018, 11, 17),
                        PublicationDate = new DateTime(1949, 06, 08),
                        DueDate = new DateTime(2018, 11, 17).AddDays(14),
                        ReturnedDate = new DateTime(2018, 11, 17).AddDays(2),
                        ExtensionCount = 0
                    },
                    new Book()
                    {
                        ID = -5,
                        Title = "The Call of Cthulhu",
                        AuthorID = -6,
                        CheckedOutDate = new DateTime(2020, 04, 22),
                        PublicationDate = new DateTime(1928, 02, 01),
                        DueDate = new DateTime(2020, 04, 22).AddDays(14),
                        ReturnedDate = new DateTime(2020, 04, 22).AddDays(12),
                        ExtensionCount = 0
                    },
                    new Book()
                    {
                        ID = -6,
                        Title = "Animal Farm",
                        AuthorID = -3,
                        CheckedOutDate = new DateTime(2020, 07, 02),
                        PublicationDate = new DateTime(1945, 08, 17),
                        DueDate = new DateTime(2020, 07, 02).AddDays(14),
                        ReturnedDate = new DateTime(2020, 07, 02).AddDays(9),
                        ExtensionCount = 0
                    },
                    new Book()
                    {
                        ID = -7,
                        Title = "Hamlet",
                        AuthorID = -5,
                        CheckedOutDate = new DateTime(2020, 09, 23),
                        PublicationDate = new DateTime(1600, 01, 01),
                        DueDate = new DateTime(2020, 09, 23).AddDays(14),
                        ReturnedDate = null,
                        ExtensionCount = 0
                    }
                    ); ;
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
