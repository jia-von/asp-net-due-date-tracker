using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Create");
        }

        /*
         Action/View “Create”
            Will display the form to create an object. 
            If the appropriate parameters are supplied in the query, attempt creation of the “Book” and add it to the list.
            If the ID is already in the list, throw an exception.
            Success message: "You have successfully checked out {title} until {DueDate}."
            Error Message: “Unable to check out book: {Exception.Message}.”
        // public Book(int id, string title, string author, DateTime publicationDate, DateTime checkedOutDate)

         */
        public IActionResult Create(string id, string title, string author, string publicationDate, string checkedOutDate)
        {
            if (Request.Query.Count > 0)
            {
                    if (id != null && title != null && author != null && publicationDate != null && checkedOutDate != null)
                    {
                    CreateBook(id, title, author, publicationDate, checkedOutDate);
                    ViewBag.Success = $"You have successfully checked out {title} until {Books.Where(x => x.ID == int.Parse(id)).Single().DueDate.ToString("d")}";
                    }
                    else
                    {
                        ViewBag.Error = "Not all fields have had values provided.";
                        ViewBag.ID = id;
                        ViewBag.Title = title;
                        ViewBag.Author = author;
                        ViewBag.PublicationDate = publicationDate;
                        ViewBag.CheckedOutDate = checkedOutDate;
                    }
            }
            return View();
        }

        // Action/View “List”
        // Render a list of all books as links that will load the “Details” Action/View.
        public IActionResult List()
        {
            ViewBag.BookLists = Books;
            return View();
        }

        /*
         
            If no get parameter “id” was supplied, render “No book selected.”
            If an “id” get parameter was supplied, use GetBookByID() and render:
            "You checked out {title} on {CheckedOutDate}, and it {is/was} due on {DueDate}."
            Use conditional rendering to make a choice about using ‘is’ or ‘was’ based on today’s date.
            A button that will call ExtendDueDateForBookByID().
            A button that will call DeleteBookByID().
         */

        // Action/View “Details”
        public IActionResult Details(string id, string extend, string delete)
        {
            int _id = int.Parse(id);
            IActionResult result;

            if(extend != null)
            {
                ExtendDueDateForBookByID(_id);
                result = RedirectToAction("List");
            }
            else if (delete != null)
            {
                DeleteBookByID(_id);
                result = RedirectToAction("List");
            }
            else
            {
                ViewBag.BookDetail = GetBookByID(_id);
                result = View();
            }

            return result;
        }

        // Method “CreateBook()”.
        // Accepts the same parameters as the “Book” constructor.
        public void CreateBook(string id, string title, string author, string publicationDate, string checkedOutDate)
        {
            // Ensures the provided ID is unique in the list.
            if (Books.Any(x => x.ID == int.Parse(id)))
            {
                // Throw an exception if the ID already exists.
                throw new Exception("Unique ID already exists." );
            }
            // Creates and adds a “Book” to the “Books” list.
            Books.Add(new Book(int.Parse(id), title, author, DateTime.Parse(publicationDate), DateTime.Parse(checkedOutDate)));
        }

        // Method “GetBookByID()”.
        // Returns the book with the given ID from the “Books” list.
        public Book GetBookByID(int id)
        {
            return Books.Where(x => x.ID == id).SingleOrDefault();
        }

        // Extensions are 7 days from the current date (7 days from when the user requests the extension, not 7 days past the “DueDate”).
        public void ExtendDueDateForBookByID(int id)
        {
            Books.Where(x => x.ID == id).SingleOrDefault().DueDate = DateTime.Now.AddDays(7);
        }


        // Removes the book with the given ID from the “Books” list.
        public void DeleteBookByID(int id)
        {
            Books.RemoveAll(x => x.ID == id);
        }

        // A public static “Books” property which is a list of “Book” objects.
        // This will be replaced by a proper database on {Day 2 assignment title}.
        public static List<Book> Books { get; set; } = new List<Book>();
    }
}
