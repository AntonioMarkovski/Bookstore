namespace Bookstore.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;  

    public class Wishlist
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        //public int PublisherId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
