namespace Bookstore.Service
{
    using Bookstore.Entities;
    using Bookstore.Entities.API.Models;
    using Bookstore.Entities.Quotes;
    using Bookstore.Repository.Interfaces;
    using Bookstore.Service.Interfaces;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Add(Book book)
        {
            _bookRepository.AddBook(book);
        }

        public void AddQuote(QuoteMap quote)
        {
            _bookRepository.AddQuote(quote);
        }

        public void Delete(int bookId)
        {
            _bookRepository.DeleteBook(bookId);
        }

        public void Edit(Book book)
        {
            _bookRepository.EditBook(book);
        }

        public void Edit(int id)
        {
            _bookRepository.EditBook(id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var result = _bookRepository.GetAllBooks();
            return result;
        }

        public IEnumerable<BookApiDTO> GetAllBooksAPI()
        {
            var result = _bookRepository.GetAllBooksAPI();
            return result;
        }

        public IEnumerable<Book> GetAllBooksWithFullRelationalData()
        {
            var result = _bookRepository.GetAllBooksWithFullRelationalData();
            return result;
        }

        public Book GetBookById(int id)
        {
            var result = _bookRepository.GetBookById(id);
            return result;
        }

        #region Helper Functions
        public Tuple<List<SelectListItem>, List<SelectListItem>, List<SelectListItem>> FillDropdowns(
            IEnumerable<Category> categories,
            IEnumerable<Author> authors,
            IEnumerable<Publisher> publishers)
        {
            List<SelectListItem> Categories = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text="Select Category ..." }
            };

            List<SelectListItem> Authors = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text="Select Author ..." }
            };

            List<SelectListItem> Publishers = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text="Select Publisher ..." }
            };

            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem { Value = category.Id.ToString(), Text = category.Name });
            }

            foreach (var author in authors)
            {
                Authors.Add(new SelectListItem { Value = author.Id.ToString(), Text = author.Name });
            }

            foreach (var publisher in publishers)
            {
                Publishers.Add(new SelectListItem { Value = publisher.Id.ToString(), Text = publisher.Name });
            }

            #region Old Static Code
            //List<SelectListItem> Categories = new List<SelectListItem>()
            //{
            //    new SelectListItem() {Text="Romance", Value="1", Selected = true},
            //    new SelectListItem() {Text= "Drama", Value="2"},
            //    new SelectListItem() {Text="Adventure", Value = "3" }
            //};

            //List<SelectListItem> Authors = new List<SelectListItem>()
            //{
            //    new SelectListItem() {Text="Agatha Christie", Value="1" , Selected = true},
            //    new SelectListItem() {Text= "Stephen King", Value="2"},
            //    new SelectListItem() {Text="William Shakespeare", Value = "3" }
            //};

            //List<SelectListItem> Publishers = new List<SelectListItem>()
            //{
            //    new SelectListItem() {Text="William Morrow Paperbacks", Value="1", Selected = true},
            //    new SelectListItem() {Text= "Scholastic", Value="2"},
            //    new SelectListItem() {Text="Penguin Random House", Value = "3" }
            //};
            #endregion

            return Tuple.Create(Categories, Authors, Publishers);
        }

        #endregion

    }
}
