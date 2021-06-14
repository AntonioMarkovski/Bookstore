namespace Bookstore.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Bookstore.Entities;
    using Bookstore.Service.Interfaces;
    using Bookstore.Models;
    using System.IO;
    using System.Net.Http.Headers;
    using Microsoft.Extensions.Logging;
    using Bookstore.Entities.Logger;
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = "admin, editor")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IConvertingService _convertingService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;
        private readonly ILogger<BookController> _logger;

        public BookController(
            IBookService bookService,
            IConvertingService convertingService,
            IAuthorService authorService,
            ICategoryService categoryService,
            IPublisherService publisherService,
            ILogger<BookController> logger
         )
        {
            _bookService = bookService;
            _convertingService = convertingService;
            _authorService = authorService;
            _categoryService = categoryService;
            _publisherService = publisherService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();
            _logger.LogInformation(LoggerMessageDisplay.BooksListed);
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryService.GetAllCategories();
            var authors = _authorService.GetAllAuthors();
            var publishers = _publisherService.GetAllPublishers();
            var dropdowns = _bookService.FillDropdowns(categories, authors, publishers);

            ViewBag.CategoryList = dropdowns.Item1;
            ViewBag.AuthorList = dropdowns.Item2;
            ViewBag.PublisherList = dropdowns.Item3;

            return View();
        }

        [HttpPost]
        public IActionResult Create(BookViewModel model)
        {
            //if (ModelState.IsValid)
            //{
                //var author = new Author();
                //author.Name = model.AuthorNameDTO;
                //author.Country = model.AuthorCountryDTO;
                //author.DateBirth = model.AuthorDateBirthDTO;
                //author.Gender = model.AuthorGenderDTO;
                //author.Language = model.AuthorLanguageDTO;
                //author.Popularity = model.AuthorPopularityDTO;
                //author.ShortDescription = model.AuthorShortDescriptionDTO;
                //_authorService.Add(author);
                // ... category, publisher...

                // *** option 1 for creating object of <book>
                //var book = new Book()
                //{
                //    AuthorID = model.AuthorID,
                //    AuthorName = model.AuthorName
                //    ...
                //    ...
                //};

            // *** option 2 for creating object of <book>
            var book = new Book();
            book.Title = model.BookTitle;
            book.AuthorID = model.AuthorID;
            book.AuthorName = model.AuthorName;
            book.BookCoverType = model.BookCoverType;
            book.BookType = model.BookType;
            book.CategoryID = model.CategoryID;
            book.CategoryName = model.CategoryName;
            book.Copies = model.Copies;
            book.Country = model.Country;
            book.DateAdded = DateTime.Now;
            book.Description = model.Description;
            book.Edition = model.Edition;
            book.Genre = model.Genre;
            book.Language = model.Language;
            book.NumberOfPages = model.NumberOfPages;
            book.PhotoURL = model.PhotoURL;
            book.Price = model.Price;
            book.PublisherName = model.PublisherName;
            book.PublisherID = model.PublisherID;
            book.Rating = model.Rating;
            book.Shipping = model.Shipping;
            book.SoldItems = model.SoldItems;
            book.Weight = model.Weight;
            book.YearOfIssue = model.YearOfIssue;
            book.Dimensions = model.Dimensions;

            // Calculate something ....
            // calculate and clean category name .....
            // var cleanedCategoryName = CleanCategory(model.CategoryNameDTO);
            // book.CategoryName = cleanedCategoryName;

            _bookService.Add(book);
            //}
            _logger.LogInformation(LoggerMessageDisplay.BookCreated);
            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Edit/2
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _bookService.GetBookById(id);
            var categories = _categoryService.GetAllCategories();
            var authors = _authorService.GetAllAuthors();
            var publishers = _publisherService.GetAllPublishers();
            var dropdowns = _bookService.FillDropdowns(categories, authors, publishers);

            ViewBag.CategoryList = dropdowns.Item1;
            ViewBag.AuthorList = dropdowns.Item2;
            ViewBag.PublisherList = dropdowns.Item3;

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(int id, Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookService.Edit(book); //_bookService.Edit(id);
                    _logger.LogInformation(LoggerMessageDisplay.BookEdited);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _logger.LogError(LoggerMessageDisplay.BookEditErrorModelStateInvalid);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageDisplay.BookEditNotFound + " | " + ex);
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var book = _bookService.GetBookById(id);
            return View(book);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetBookById(id);
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            // *** option 1 to get the book
            var book = _bookService.GetBookById(id);
            _bookService.Delete(book.Id);

            // *** option 2 to get the book
            //_bookService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "admin, editor")]
        public JsonResult GetAllBooksAJAX()
        {
            var allBooks = _bookService.GetAllBooks();
            return Json(new { booksData = allBooks });
        }

        [HttpPost]
        public IActionResult UploadPhoto()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "photos");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = fileName;

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                } 
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex);
            }
        }


    }
}
