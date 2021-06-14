namespace Bookstore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        [Key]
        public int Id { get; set; }

        [StringLength(350)]
        public string Title { get; set; }

        [StringLength(350)]
        [Display(Name = "Author")]
        public string AuthorName { get; set; }

        [Display(Name = "Author")]
        public int AuthorID { get; set; }
        public Author Author { get; set; }

        [Display(Name = "Year of issue")]
        public DateTime YearOfIssue { get; set; }

        [Display(Name = "Pages")]
        public int NumberOfPages { get; set; }

        [StringLength(350)]
        [Display(Name = "Publisher")]
        public string PublisherName { get; set; }

        [Display(Name = "Publisher")]
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }

        public int UserId { get; set; }

        [StringLength(150)]
        public string Genre { get; set; }

        [StringLength(150)]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }   

        public double Price { get; set; }

        [StringLength(50)]
        [Display(Name = "Book type")]
        public string BookType { get; set; } // EBook, AudioBook, Fisical Book

        [StringLength(50)]
        [Display(Name = "Book cover type")]
        public string BookCoverType { get; set; } // Cover Type

        [StringLength(1500)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Language { get; set; }

        [StringLength(150)]
        public string Country { get; set; }

        public int Edition { get; set; }

        [StringLength(50)]
        public string Dimensions { get; set; }

        public double Weight { get; set; }

        public int Copies { get; set; }

        [StringLength(50)]
        public string Shipping { get; set; }

        [Display(Name = "Photo")]
        public string PhotoURL { get; set; }

        [Display(Name = "Number of sold items")]
        public int SoldItems { get; set; }
        
        public double Rating { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        public string Test { get; set; }

        //public ICollection<Photo> Photos { get; set; }
        //public virtual ICollection<Publisher> Publishers { get; set; }
    }
}
