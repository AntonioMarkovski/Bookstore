namespace Bookstore.Models
{
    using Bookstore.Entities;
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public IEnumerable<Book> AllBooksList { get; set; }
    }
}
