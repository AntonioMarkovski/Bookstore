namespace Bookstore.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bookstore.Data;
    using Bookstore.Entities;
    using Bookstore.Entities.API.Models;
    using Bookstore.Entities.Logger;
    using Bookstore.Entities.Quotes;
    using Bookstore.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(DataContext context, ILogger<BookRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddBook(Book book)
        {
            try
            {
                // "INSERT INTO ....VALUES "
                _context.Books.Add(book);
                _context.SaveChanges();
                _logger.LogInformation(LoggerMessageDisplay.BookCreated);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageDisplay.BookNotCreatedModelStateInvalid + " | " + ex);
                throw;
            }
        }

        public void AddQuote(QuoteMap quote)
        {
            try
            {
                _context.Quotes.Add(quote);
                _context.SaveChanges();
                _logger.LogInformation("Quote Added to DB");
            }
            catch (Exception ex)
            {
                _logger.LogError("Quote NOT Added to DB | " + ex);
                throw;
            }
        }

        public void DeleteBook(int bookId)
        {
            Book book = GetBookById(bookId);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public void EditBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void EditBook(int id)
        {
            var book = GetBookById(id);
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            //var result = _context.Books.FromSqlRaw("SELECT * FROM Books").AsEnumerable();
            var result = _context.Books.AsEnumerable();
            return result;
        }

        public IEnumerable<BookApiDTO> GetAllBooksAPI()
        {         
            var bookList = new List<BookApiDTO>();
            var result = _context.Books.AsEnumerable();

            foreach (var book in result)
            {
                var bookDTO = new BookApiDTO()
                {
                    Title = book.Title,
                    Author = book.AuthorName,
                    Publisher = book.PublisherName
                };
                bookList.Add(bookDTO);
            }

            return bookList.AsEnumerable();
        }

        public IEnumerable<Book> GetAllBooksWithFullRelationalData()
        {
            var result = _context.Books
                .Include(a => a.Author)
                .Include(c => c.Category)
                .Include(p => p.Publisher)
                .AsEnumerable();
            return result;
        }

        public Book GetBookById(int id)
        {
            //var result = _context.Books.FromSqlRaw("SELECT * FROM Books WHERE Id = " + id).FirstOrDefault(); ;
            var result = _context.Books.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
