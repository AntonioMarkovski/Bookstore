namespace Bookstore.Service.Interfaces
{
    using Bookstore.Entities;
    using Bookstore.Entities.API.Models;
    using Bookstore.Entities.Quotes;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;

    public interface IBookService
    {
        void Add(Book book);
        void Edit(Book book);
        void Edit(int id);
        void Delete(int bookId);

        Book GetBookById(int id);

        IEnumerable<Book> GetAllBooks();

        IEnumerable<BookApiDTO> GetAllBooksAPI();

        Tuple<List<SelectListItem>, List<SelectListItem>, List<SelectListItem>> FillDropdowns(
            IEnumerable<Category> categories, 
            IEnumerable<Author> authors, 
            IEnumerable<Publisher> publishers);

        IEnumerable<Book> GetAllBooksWithFullRelationalData();

        void AddQuote(QuoteMap quote);
    }
}
