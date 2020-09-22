using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    // Add a code-first Author class (Model) (all properties public, not null unless specified otherwise):
    [Table("Author")]
    public partial class Author
    {
        // int “ID” - int(10) (prmary key)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int(10)")]
        public int ID { get; set; }

        // string “Name” - varchar(30)
        [Column("name", TypeName = "varchar(30)")]
        [Required]
        public string Name { get; set; }

        // Requisite virtual property and constructor for foreign key.
        [InverseProperty(nameof(Book.Authors))]
        public virtual ICollection<Book> Books { get; set; }

    }
}
