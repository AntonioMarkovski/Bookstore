using Bookstore.Entities;
using Bookstore.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.API.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookAPIController : ControllerBase
    {
        private IBookService _bookService;
        private ILogger<BookAPIController> _logger;

        public BookAPIController(IBookService bookService, ILogger<BookAPIController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet("GetBooks")]
        public IEnumerable<Book> GetBooks()
        {
            var bookList = _bookService.GetAllBooks();
            return bookList;
        }

        [HttpGet("GetBook")]
        public Book GetBook()
        {
            var bookList = _bookService.GetBookById(1);
            return bookList;
        }

        [HttpGet("RandomBook")]
        public Book GetRandomBook()
        {
            //var rnd = new Random();
            //var rndVal = rnd.Next(1, 22);

            var findBook = _bookService.GetBookById(new Random().Next(1, _bookService.GetAllBooks().Max(m => m.Id)));
            //var findBook = _bookService.GetBookById(21);
            if (findBook == null)
            {
                do
                {
                    findBook = _bookService.GetBookById(new Random().Next(1, _bookService.GetAllBooks().Max(m => m.Id)));
                    //findBook = _bookService.GetBookById(21); // *** infinite loop
                } while (findBook == null);

                return findBook;
            }
            else
            {
                return findBook;
            }
        }

    }
}
