namespace Bookstore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Bookstore.Entities;

    public class BookViewModel
    {
        #region Book Data

        [StringLength(350)]
        public string BookTitle { get; set; }

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

        #endregion

        #region Author Data
        
        [StringLength(100)]
        public string AuthorNameDTO { get; set; }

        [StringLength(100)]
        public string AuthorCountryDTO { get; set; }

        public DateTime AuthorDateBirthDTO { get; set; }

        [StringLength(1500)]
        public string AuthorShortDescriptionDTO { get; set; }

        [StringLength(50)]
        public string AuthorLanguageDTO { get; set; }

        [StringLength(50)]
        public string AuthorGenderDTO { get; set; }

        public bool AuthorPopularityDTO { get; set; }

        #endregion

        #region Category Data

        public string CategoryNameDTO { get; set; }

        #endregion

        #region Publisher Data

        [StringLength(100)]
        public string PublisherNameDTO { get; set; }

        [StringLength(100)]
        public string PublisherCountryDTO { get; set; }

        [StringLength(50)]
        public string PublisherYearDTO { get; set; }

        #endregion

        #region Wishlist Data
        public double WishlistTotalPrice { get; set; }

        #endregion

        #region Shopping Cart Data
        public int AddToCartTotalCounter { get; set; }
        #endregion

        #region Search
        public string SearchString { get; set; }
        #endregion

        #region Other Landing Page Data

        public IEnumerable<Book> TopPopularBooks { get; set; }
        public IEnumerable<Book> TopPopularBooksByBestSellingAuthor { get; set; }
        public Author BestSellingAuthor { get; set; }
        public IEnumerable<Book> AllBooks { get; set; }
        public IEnumerable<Book> AllBooksFromWishlistByLoggedInUser { get; set; }

        #endregion
    }
}
