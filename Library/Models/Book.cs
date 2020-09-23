using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    // Modify “Book” (Model):
    [Table("book")]
    public partial class Book
    {
        [Key]
        [Column("ID", TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column("Title", TypeName = "varchar(30)")]
        public string Title { get; set; }

        [Column("PublicationDate", TypeName = "date")]
        public DateTime PublicationDate { get; set; }

        [Column("CheckedOutDate", TypeName = "date")]
        public DateTime CheckedOutDate { get; set; }

        [Column("DueDate", TypeName = "date")]
        public DateTime DueDate { get; set; }

        [Column("ReturnedDate", TypeName = "date")]
        public DateTime? ReturnedDate { get; set; }

        // Add a property “ExtensionCount” - int(10), not nullable.
        [Required]
        [Column("ExtensionCount", TypeName = "int(10)")]
        public int ExtensionCount { get; set; }

        [Column("AuthorID", TypeName = "int(10)")]
        public int AuthorID { get; set; }

        // This attribute specifies which database field is the foreign key. Typically in the child (many side of the 1-many).
        [ForeignKey(nameof(AuthorID))]

        // InverseProperty links the two virtual properties together.
        [InverseProperty(nameof(Models.Author.Books))]
        public virtual Author Author { get; set; }
    }

}

