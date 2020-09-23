using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    // Modify “BookController” (Controller):
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        public IActionResult Create(string id, string title, string authorID, string publicationDate, string checkedOutDate)
        {

            ViewBag.Authors = GetAuthors();

            if (Request.Query.Count > 0)
            {
                try
                {
                    if (title != null && authorID != null && publicationDate != null && checkedOutDate != null)
                    {
                        // Get parameters come in as a string, so we have to convert those to the data types required.
                        Book createdBook = CreateBook(title, int.Parse(authorID), DateTime.Parse(publicationDate), DateTime.Parse(checkedOutDate));

                        ViewBag.Success = $"You have successfully checked out {createdBook.Title} until {createdBook.DueDate}.";
                    }
                    else
                    {
                        throw new Exception("Not all fields provided for book creation.");
                    }
                }
                catch (Exception e)
                {
                    // All expected data not provided, so this will be our error state.
                    ViewBag.Error = $"Unable to check out book: {e.Message}";

                    // Store our data to re-add to the form.
                    ViewBag.ID = id;
                    ViewBag.BookTitle = title;
                    ViewBag.AuthorID = authorID;
                    ViewBag.PublicationDate = publicationDate;
                    ViewBag.CheckedOutDate = checkedOutDate;
                }
            }
            // else
            // No request, so this will be our inital state.

            return View();
        }
        public IActionResult List()
        {
            ViewBag.Books = GetBooks();

            return View();
        }
        public IActionResult Details(string id, string delete, string extend)
        {
            IActionResult result;


            // If ID wasn't provided, or if it won't parse to an int, or the ID doesn't exist.
            if (id == null || !int.TryParse(id, out int temp))
            {
                ViewBag.Error = "No book selected.";
                result = View();
            }
            else
            {
                if (delete != null)
                {
                    DeleteBookByID(int.Parse(id));
                    result = RedirectToAction("List");
                }
                else
                {
                    if (extend != null)
                    {
                        ExtendDueDateForBookByID(int.Parse(id));
                    }
                    Book target = GetBookByID(int.Parse(id));
                    if (target == null)
                    {
                        ViewBag.Error = "No book selected.";
                    }
                    else
                    {
                        ViewBag.Book = target;
                    }
                    result = View();
                }
            }
            return result;
        }

        /*
         Modify “CreateBook()”.
                Check that “Title” is unique before saving books to the database.
                If “Title” is not unique do not add the new book.
                Ensure this comparison is case insensitive and trimmed.
         
         */
        public Book CreateBook(string title, int authorID, DateTime publicationDate, DateTime checkedOutDate)
        {
            Book newBook = new Book()
            {
                Title = title,
                AuthorID = authorID,
                PublicationDate = publicationDate,
                CheckedOutDate = checkedOutDate,
                DueDate = checkedOutDate.AddDays(14),
                ReturnedDate = null
            };

            using (LibraryContext context = new LibraryContext())
            {
                context.Books.Add(newBook);
                context.SaveChanges();
            }

            return newBook;
        }
        public Book GetBookByID(int id)
        {
            Book target;
            using (LibraryContext context = new LibraryContext())
            {
                target = context.Books.Where(x => x.ID == id).Single();
                target.Author = context.Authors.Where(x => x.ID == target.AuthorID).SingleOrDefault();
            }
            return target;
        }
        // This should really be in author controller but it's scaffolded and I don't want to mess with it for this example.
        public List<Author> GetAuthors()
        {
            List<Author> authors;
            using (LibraryContext context = new LibraryContext())
            {
                authors = context.Authors.ToList();
                foreach (Author author in authors)
                {
                    author.Books = context.Books.Where(x => x.AuthorID == author.ID).ToList();
                }
            }
            return authors;
        }
        public List<Book> GetBooks()
        {
            List<Book> books;
            using (LibraryContext context = new LibraryContext())
            {
                books = context.Books.ToList();
                foreach (Book book in books)
                {
                    book.Author = context.Authors.Where(x => x.ID == book.AuthorID).Single();
                }
            }
            return books;
        }
        public void ExtendDueDateForBookByID(int id)
        {
            using (LibraryContext context = new LibraryContext())
            {
                context.Books.Where(x => x.ID == id).Single().DueDate = DateTime.Now.Date.AddDays(7);
                context.SaveChanges();
            }
        }
        public void DeleteBookByID(int id)
        {
            Book target;
            using (LibraryContext context = new LibraryContext())
            {
                target = context.Books.Where(x => x.ID == id).Single();
                context.Books.Remove(target);
                context.SaveChanges();
            }
        }
    }
}