namespace Bookstore.Models
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Bookstore.Entities;

    public class ShopCartViewModel
    {
        // Book Data
        public int BookID { get; set; }
        public string Title { get; set; }
        public DateTime YearOfIssue { get; set; }
        public int NumberOfPages { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public string BookType { get; set; }
        public string Dimensions { get; set; }
        public double Weight { get; set; }
        public string Shipping { get; set; }
        public string MainPhotoURL { get; set; }

        // Author Data
        public string AuthorName { get; set; }
        public int AuthorID { get; set; }

        // Publisher Data
        public string PublisherName { get; set; }
        public string PublisherCountry { get; set; }
        public int PublisherID { get; set; }

        // Category Data
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        // Wishlist Data
        public double WishlistTotalPrice { get; set; }

        // Order Data
        public double SubTotal { get; set; }
        public double ShippingTotal { get; set; }
        public double TotalPrice { get; set; }
        public double AddToCartTotalCounter { get; set; }
        public double TotalWeight { get; set; }

        // Shipping Address Data
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AddressOptional { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        // Card Data
        public int CardNumber { get; set; }
        public string CardHolder { get; set; }
        public string CardExpirationDate { get; set; }
        public string CardCVV { get; set; }

        // Other Data
        public IEnumerable<Book> AllBooks { get; set; }
        public IEnumerable<Book> AllBooksFromWishlistByLoggedInUser { get; set; }
        public IEnumerable<Book> AllBooksAddedToCartByLoggedInUser { get; set; }
    }
}
