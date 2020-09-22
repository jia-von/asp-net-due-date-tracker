using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    // Book class (Model) modified to serve as a database code-first class:
    [Table("Book")]
    public partial class Book
    {
        [Key]
        // int “ID” - int(10) (primary key)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int(10)")]
        public int ID { get; set; }

        // string “Title” - varchar(30)
        [Column("title", TypeName = "varchar(30)")]
        [Required]
        public string Title { get; set; }

        // DateTime “PublicationDate” - date
        [Column("publication_date", TypeName = "date")]
        [Required]
        public DateTime PublicationDate { get; set; }
        // DateTime “CheckedOutDate” - date
        [Column("checked_out_date", TypeName = "date")]
        [Required]
        public DateTime CheckedOutDate { get; set; }

        // DateTime “DueDate” - date
        [Column("due_date", TypeName = "date")]
        [Required]
        public DateTime DueDate { get; set; }

        // DateTime “ReturnedDate” - date (nullable)
        [Column("returned_date", TypeName = "date")]
        public DateTime? ReturnedDate { get; set; }

        // int “AuthorID” - int(10) (foreign key)
        [Column("author_id", TypeName = "int(10)")]
        public string AuthorID { get; set; }

        // Points to the property representing the foreign key column.
        [ForeignKey(nameof(AuthorID))]

        // By using nameof() it saves us from breaking it accidentally by renaming things, as long as we use Ctrl+R+R to rename them. For some reason the migration from an existing database doesn't use this, which is why things breaks
        [InverseProperty(nameof(Author.Books))]
        public virtual Author Authors { get; set; }



        public Book(int id, string title, DateTime publicationDate, DateTime checkedOutDate) //string author was removed from parameters
        {
            ID = id;
            Title = title;
            // Author = author;
            PublicationDate = publicationDate;
            CheckedOutDate = checkedOutDate;
            DueDate = CheckedOutDate.AddDays(14); 
            ReturnedDate = null; 
        }

    }
}
