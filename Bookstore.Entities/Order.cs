using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bookstore.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string BookCountry { get; set; }
        public string BookPublisher { get; set; }
        public string BookCategory { get; set; }
        public string BookType { get; set; }
        public string BookDimensions { get; set; }
        public string BookWeight { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
