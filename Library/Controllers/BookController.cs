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
    // BookController (Controller) class modified:
    public class BookController : Controller
    {
        // Remove the “Books” property (static list of Books).
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        public IActionResult Create(string title, string author, string publicationDate, string checkedOutDate)
        {
            if (Request.Query.Count > 0)
            {
                try
                {
                    if (title != null && author != null && publicationDate != null && checkedOutDate != null)
                    {
                        // Get parameters come in as a string, so we have to convert those to the data types required.
                        Book createdBook = CreateBook(title, author, DateTime.Parse(publicationDate), DateTime.Parse(checkedOutDate));

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
                    ViewBag.BookTitle = title;
                    ViewBag.Author = author;
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
            ViewBag.BookList = GetBooks();
            return View();
        }
        public IActionResult Details(string id, string delete, string extend)
        {
            IActionResult result;
            using(LibraryContext contxt = new LibraryContext())
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
                        ViewBag.Book = GetBookByID(int.Parse(id));
                        result = View();
                    }

                return result;
            }

        }
        /*
         Modify “CreateBook()” to save books to a database using Entity Framework.
                Have “CreateBook()” perform the nulling of “ReturnDate”.
                Have “CreateBook()” perform the setting of “DueDate”.
         */
        public Book CreateBook(string title, string author, DateTime publicationDate, DateTime checkedOutDate)
        {
            Book newBook = new Book() { Title = title, PublicationDate = publicationDate, CheckedOutDate = checkedOutDate };

            using (LibraryContext context = new LibraryContext())
            {
                newBook.AuthorID = context.Authors.Where(x => x.Name == author).Single().ID;
                context.Books.Add(newBook);
                context.SaveChanges();
            }
            return newBook;
        }
        // Modify “GetBookByID()” to get a specific book from the database.
        // Ensure that the “Author” virtual property is populated before the object is returned (for use on the Details view). --TODO
        public Book GetBookByID(int id)
        {
            Book target;

            using (LibraryContext context = new LibraryContext())
            {
                target = context.Books.Where(x => x.ID == id).Single();
                target.Authors = context.Authors.Where(x => x.ID == target.AuthorID).Single();
            }
            return target;
        }
        // Modify “ExtendDueDateForBookByID()” to update a book in the database using Entity Framework.
        public void ExtendDueDateForBookByID(int id)
        {
            GetBookByID(id).DueDate = DateTime.Now.Date.AddDays(7);
        }
        // Modify “DeleteBookByID()” to delete a book from the database using Entity Framework.
        // Removes the book with the given ID from the “Books” list.
        // Books.Remove(Books.Where(x => x.ID == id).Single());
        public void DeleteBookByID(int id)
        {
            using (LibraryContext context = new LibraryContext())
            {
                context.Books.Remove(context.Books.Where(x => x.ID == id).Single());
            }
        }

        // Add a “GetBooks()” method to get a list of all books in the database using Entity Framework.
        // Ensure that the “Author” virtual property is populated before the list is returned (for use on the List view). ---TODO----
        public List<Book> GetBooks()
        {
            List<Book> bookList = new List<Book>();

            using (LibraryContext context = new LibraryContext())
            {
                bookList = context.Books.ToList();
                bookList.ForEach(x => x.Authors = context.Authors.Where(y => y.ID == x.AuthorID).Single());
            }
            return bookList;
        }
    }
}