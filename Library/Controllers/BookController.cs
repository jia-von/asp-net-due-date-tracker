using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Library.Models;
using Library.Models.Exceptions;
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
        public IActionResult Create(string title, string authorID, string publicationDate)
        {

            ViewBag.Authors = GetAuthors();

            if (Request.Query.Count > 0)
            {
                try
                {

                    // Get parameters come in as a string, so we have to convert those to the data types required.
                    Book createdBook = CreateBook(title, int.Parse(authorID), publicationDate);

                    ViewBag.Success = $"You have successfully checked out {createdBook.Title} until {createdBook.DueDate}.";

                }
                catch (ValidationExceptions e)
                {
                    // All expected data not provided, so this will be our error state.
                    ViewBag.Exception = e;

                    // Store our data to re-add to the form.
                    ViewBag.BookTitle = title;
                    ViewBag.AuthorID = authorID;
                    ViewBag.PublicationDate = publicationDate;
                }
            }
            // else
            // No request, so this will be our inital state.

            return View();
        }
        // Create a form with a checkbox “Filter to Overdue”.
        // When the page loads with the checkbox checked (GET parameter), call the “GetOverdueBooks()” method instead of the “GetBooks()” method.
        public IActionResult List(string filter)
        {
            if(filter == "on")
            {
                ViewBag.Books = GetOverdueBooks();
            }
            else
            {
                ViewBag.Books = GetBooks();
            }

            return View();
        }
        public IActionResult Details(string id, string delete, string extend, string returnbook)
        {
            IActionResult result;

            // If ID wasn't provided, or if it won't parse to an int, or the ID doesn't exist.
            if (id == null || !int.TryParse(id, out int temp))
            {
                ViewBag.Error = "No book selected.";
                result = View();
            }
            else 
            if (delete != null)
            {
                DeleteBookByID(int.Parse(id));
                result = RedirectToAction("List");
            }else
                {
                    if (extend != null)
                    {
                        try
                        {
                            ExtendDueDateForBookByID(int.Parse(id));
                        }
                        catch (ValidationExceptions e)
                        {

                            ViewBag.Exception = e;
                        }
                    }
                    
                    if (returnbook != null)
                    {
                        try
                        {
                            ReturnBookByID(int.Parse(id));
                        }
                        catch (ValidationExceptions e)
                        {
                            ViewBag.Exception = e;
                        }

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
            return result;
        }

        /*
         Modify “CreateBook()”.
                Check that “Title” is unique before saving books to the database.
                If “Title” is not unique do not add the new book.
                Ensure this comparison is case insensitive and trimmed.
         
         */
        public Book CreateBook(string title, int authorID, string publicationDate)
        {

            // Display itemized errors for every field that has an issue.
            ValidationExceptions exception = new ValidationExceptions();

            // “Title” cannot be empty or whitespace.
            if(string.IsNullOrWhiteSpace(title))
            {
                exception.SubExceptions.Add(new Exception("The title cannot be empty."));
            }
            else // “Title” cannot exceed its size in the database.          
            if (title.Trim().Length > 30)
            {
                exception.SubExceptions.Add(new Exception("The title cannot exceed 30 characters."));
            }
            else
            if (GetBooks().Any(x => x.Title.ToLower() == title.Trim().ToLower()))
            {   // Ensure this comparison is case insensitive and trimmed.
                // If “Title” is not unique do not add the new book.
                exception.SubExceptions.Add(new Exception("This title is already recorded in the database. Please add new title."));
            }

            // “PublishedDate” cannot be in the future
            if(publicationDate == null)
            {
                exception.SubExceptions.Add(new Exception("Please insert a publication date."));
            }else 
            if (DateTime.Compare(DateTime.Parse(publicationDate), DateTime.Now)>0)
            {
                exception.SubExceptions.Add(new Exception("Publication date cannot be in the future."));
            }
            
            if(exception.SubExceptions.Count>0)
            {
                throw exception;
            }
            
            Book newBook = new Book()
            {
                // Trim “Title” before saving it’s value.
                Title = title.Trim(),
                AuthorID = authorID,
                PublicationDate = DateTime.Parse(publicationDate),

                // Set “CheckedOutDate” to today’s date.
                CheckedOutDate = DateTime.Now,

                // Keep the logic to set DueDate and ReturnedDate.
                DueDate = DateTime.Now.AddDays(14),
                ReturnedDate = null,

                // Set “ExtensionCount” to 0.
                ExtensionCount = 0
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
            ValidationExceptions exception = new ValidationExceptions();
            Book target;

            using (LibraryContext context = new LibraryContext())
            {
                target = context.Books.Where(x => x.ID == id).Single();

                // A book can only be extended a maximum of 3 times.
                if (target.ExtensionCount < 3 && DateTime.Compare(DateTime.Now, target.DueDate)<0)
                {
                    target.DueDate = DateTime.Now.AddDays(7);
                    target.ExtensionCount += 1;
                    context.SaveChanges();
                }else 
                if(target.ExtensionCount > 3)
                {
                    // If a user tries to extend a book a fourth time do not update the database
                    // Display an error on the page calling the method informing the user they will have to speak to the librarian.
                    exception.SubExceptions.Add(new Exception("Cannot extend book more than four times. Kindly speak to a librarian."));
                    throw exception;

                }else if(DateTime.Compare(DateTime.Now, target.DueDate) > 0)
                {
                    // Overdue books cannot be extended.
                    // Display an error on the page calling the method informing the user they will have to speak to the librarian.
                    exception.SubExceptions.Add(new Exception("Overdue book cannot be extended. Kindly speak to a librarian."));
                    throw exception;
                }
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

        // Add a “ReturnBookByID()” method.
        // Set the returned date of the specified book to today’s date.
        // Overdue books cannot be returned.
        // Display an error on the page calling the method informing the user they will have to speak to the librarian.
        public void ReturnBookByID(int id)
        {
            Book target;
            ValidationExceptions exception = new ValidationExceptions();
            using (LibraryContext context = new LibraryContext())
            {
                target = context.Books.Where(x => x.ID == id).Single();

                if(DateTime.Compare(DateTime.Now, target.DueDate) < 0)
                {
                    target.ReturnedDate = DateTime.Now;
                    context.SaveChanges();
                }else
                {
                    exception.SubExceptions.Add(new Exception("Cannot return book, kindly speak to a librarian."));
                    throw exception;
                }
            }
        }

        // Add a “GetOverdueBooks()” method.
        // Return a list of books with “DueDate” in the past, that have no “ReturnedDate”.
        public List<Book> GetOverdueBooks()
        {
            List<Book> overdueList = new List<Book>();

            using (LibraryContext context = new LibraryContext())
            {
                overdueList = context.Books.Where(x => DateTime.Compare(DateTime.Now, x.DueDate) > 0 && x.ReturnedDate == null).ToList();

                foreach(Book book in overdueList)
                {
                    book.Author = context.Authors.Where(x => x.ID == book.AuthorID).Single();
                }
            }
            return overdueList;
        }

    }
}
