using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bookstore.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Country { get; set; }
        
        public DateTime DateBirth { get; set; }

        [StringLength(1500)]
        public string ShortDescription { get; set; }

        [StringLength(50)]
        public string Language { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        public bool Popularity { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
