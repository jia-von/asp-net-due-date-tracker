//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Library.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace Library.Controllers
//{
//    // BookController (Controller) class modified:
//    public class BookController : Controller
//    {
//        // Remove the “Books” property (static list of Books).
//        public IActionResult Index()
//        {
//            return RedirectToAction("List");
//        }
//        public IActionResult Create(string id, string title, string author, string publicationDate, string checkedOutDate)
//        {
//            if (Request.Query.Count > 0)
//            {
//                try
//                {
//                    if (id != null && title != null && author != null && publicationDate != null && checkedOutDate != null)
//                    {
//                        // Get parameters come in as a string, so we have to convert those to the data types required.
//                        Book createdBook = CreateBook(int.Parse(id), title, author, DateTime.Parse(publicationDate), DateTime.Parse(checkedOutDate));

//                        ViewBag.Success = $"You have successfully checked out {createdBook.Title} until {createdBook.DueDate}.";
//                    }
//                    else
//                    {
//                        throw new Exception("Not all fields provided for book creation.");
//                    }
//                }
//                catch (Exception e)
//                {
//                    // All expected data not provided, so this will be our error state.
//                    ViewBag.Error = $"Unable to check out book: {e.Message}";

//                    // Store our data to re-add to the form.
//                    ViewBag.ID = id;
//                    ViewBag.BookTitle = title;
//                    ViewBag.Author = author;
//                    ViewBag.PublicationDate = publicationDate;
//                    ViewBag.CheckedOutDate = checkedOutDate;
//                }
//            }
//            // else
//            // No request, so this will be our inital state.

//            return View();
//        }
//        public IActionResult List()
//        {
//            ViewBag.Books = Books;

//            return View();
//        }
//        public IActionResult Details(string id, string delete, string extend)
//        {
//            IActionResult result;

//            // If ID wasn't provided, or if it won't parse to an int, or the ID doesn't exist.
//            if (id == null || !int.TryParse(id, out int temp) || Books.Where(x => x.ID == int.Parse(id)).Count() < 1)
//            {
//                ViewBag.Error = "No book selected.";
//                result = View();
//            }
//            else
//            {
//                if (delete != null)
//                {
//                    DeleteBookByID(int.Parse(id));
//                    result = RedirectToAction("List");
//                }
//                else
//                {
//                    if (extend != null)
//                    {
//                        ExtendDueDateForBookByID(int.Parse(id));
//                    }
//                    ViewBag.Book = GetBookByID(int.Parse(id));
//                    result = View();
//                }
//            }
//            return result;
//        }
//        public Book CreateBook(int id, string title, string author, DateTime publicationDate, DateTime checkedOutDate)
//        {
//            /*
//            Accepts the same parameters as the “Book” constructor.
//            Creates and adds a “Book” to the “Books” list.
//            Ensures the provided ID is unique in the list.
//            Throw an exception if the ID already exists.
//            */
//            if (Books.Where(x => x.ID == id).Count() > 0)
//            {
//                throw new Exception("That ID already exists.");
//            }

//            Book newBook = new Book(id, title, author, publicationDate, checkedOutDate);
//            Books.Add(newBook);
//            return newBook;
//        }
//        // Add a “GetBooks()” method to get a list of all books in the database using Entity Framework.
//        public Book GetBookByID(int id)
//        {
//            // Returns the book with the given ID from the “Books” list.
//            return Books.Where(x => x.ID == id).Single();
//        }
//        // Modify “ExtendDueDateForBookByID()” to update a book in the database using Entity Framework.
//        public void ExtendDueDateForBookByID(int id)
//        {
//            GetBookByID(id).DueDate = DateTime.Now.Date.AddDays(7);
//        }
//        // Modify “DeleteBookByID()” to delete a book from the database using Entity Framework.
//        public void DeleteBookByID(int id)
//        {
//            // Removes the book with the given ID from the “Books” list.
//            Books.Remove(Books.Where(x => x.ID == id).Single());
//        }
//    }
//}