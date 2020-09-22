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

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }

        // Database connection string to a database called “mvc_library”.
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

                // 5 “Authors” of your choice.
                entity.HasData(
                    new Author()
                    {
                        ID = -1,
                        Name = "William Shakespeare"
                    },
                    new Author()
                    {
                        ID = -2,
                        Name = "Agatha Christie"
                    },
                    new Author()
                    {
                        ID = -3,
                        Name = "Barbara Cartland"
                    },
                    new Author()
                    {
                        ID = -4,
                        Name = "Danielle Steel"
                    },
                    new Author()
                    {
                        ID = -5,
                        Name = "Harold Robbins"
                    }
                );
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.AuthorID)
                    .HasName("FK_Book_Author");

                entity.Property(e => e.Title)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
                OnModelCreatingPartial(modelBuilder);

                entity.HasOne(d => d.Authors)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Book_Author");

                // 3 “Books” by the same Author.   
                // All three books must have a “CheckoutDate” equal to December 25, 2019.
                entity.HasData(
                    // One book must be returned on-time with no extension.
                    new Book
                    {
                        ID = -1,
                        Title = "Measure for Measure",
                        AuthorID = -1,
                        PublicationDate = new DateTime(1604, 01, 01),
                        CheckedOutDate = new DateTime(2019, 12, 25),
                    },

                    // One book must be returned on-time with one extension.
                    new Book
                    {
                        ID = -2,
                        Title = "Troilus and Cressida",
                        AuthorID = -1,
                        PublicationDate = new DateTime(1602, 01, 01),
                        CheckedOutDate = new DateTime(2019, 12, 25),
                        DueDate = DateTime.Now.AddDays(7)
                    },

                    // One book must not have been returned at all!
                    new Book
                    {
                        ID = -3,
                        Title = "Hamlet",
                        AuthorID = -1,
                        PublicationDate = new DateTime(1599, 01, 01),
                        CheckedOutDate = new DateTime(2019, 12, 25),
                        ReturnedDate = null
                    }); 
            });
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
