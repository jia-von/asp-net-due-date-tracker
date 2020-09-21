using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    // Book class (Model):
    public class Book
    {
        // string “Title”
        // This property should be readOnly (getter only, backing variable initialized via constructor)
        private string _title;
        public string Title { get => _title; }

        // DateTime “PublicationDate”
        // This property should be readOnly(getter only, backing variable initialized via constructor)
        private DateTime _publicationDate;
        public DateTime PublicationDate { get => _publicationDate; }

        // DateTime “CheckedOutDate”
        public DateTime CheckedOutDate { get; set; }

        // DateTime “DueDate”
        // This will equal “CheckedOutDate” + 14 days (set in constructor)
        // This will update with each extension(via the ExtendDueDateForBookByID() method)
        public DateTime DueDate { get; set; }

        // DateTime “ReturnedDate”
        // Default value should be null (set in constructor)
        public DateTime? ReturnedDate { get; set; }

        // string “Author”
        // This property should be readOnly(getter only, backing variable initialized via constructor)
        private string _author;
        public string Author { get => _author; }

        /*
         int “ID”
            This property should be readOnly (getter only, backing variable initialized via constructor)
            This property will be auto-incremented by the database in tomorrow’s practice
            User will have to add “ID” on Day 1 and the code will have to validate that the “ID” is unique (in the CreateBook() method)
         */
        private int _id;
        public int ID { get => _id; }

        /*
         Constructor accepting the ID, Title, Author, PublicationDate and CheckedOutDate as parameters
            “DueDate” will be set to 14 days after “CheckedOutDate”
            “ReturnedDate” will be set to null   
         */

        public Book()
        {
            _id = 0;
            _title = "Default Title";
            _author = "Default Author";
            _publicationDate = DateTime.Now;
            CheckedOutDate = DateTime.Now;
            DueDate = CheckedOutDate.AddDays(14);
            ReturnedDate = null;
        }

    }
}
