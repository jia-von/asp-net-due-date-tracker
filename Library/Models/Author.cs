using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("author")]
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [Column("ID", TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Required]
        [Column("Name", TypeName = "varchar(30)")]
        public string Name { get; set; }


        // InverseProperty links the two virtual properties together.
        [InverseProperty(nameof(Models.Book.Author))]
        public virtual ICollection<Book> Books { get; set; }
    }
}
