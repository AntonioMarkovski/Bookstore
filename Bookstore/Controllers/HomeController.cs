namespace Bookstore.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Bookstore.Entities;
    using Bookstore.Entities.Quotes;
    using Bookstore.Models;
    using Bookstore.Service.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Http;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IWishlistService _wishlistService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(
            ILogger<HomeController> logger,
            IBookService bookService,
            IShoppingCartService shoppingCartService,
            IWishlistService wishlistService,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _bookService = bookService;
            _shoppingCartService = shoppingCartService;
            _wishlistService = wishlistService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();
            var booksWithFullData = _bookService.GetAllBooksWithFullRelationalData();
            
            var homeViewModel = new HomeViewModel()
            {
                AllBooksList = books
            };
            return View(homeViewModel); //PartialView(); 
        }

        public async Task<JsonResult> GetQuotes()
        {
            QuotesData quotesData = new QuotesData();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://opinionated-quotes-api.gigalixirapp.com/v1/quotes"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    quotesData = JsonConvert.DeserializeObject<QuotesData>(apiResponse);
                    
                    //foreach (var quote in quotesData.Quotes)
                    //{
                    //    QuoteMap newQuote = new QuoteMap()
                    //    {
                    //        Author = quote.Author,
                    //        Lang = quote.Lang,
                    //        Quote = quote.quote,
                    //        Tags = string.Join(",", quote.Tags.ToArray())
                    //    };

                    //    _bookService.AddQuote(newQuote);
                    //}
                }
            }

            return Json(quotesData);
        }

        public int AddToCartNotificationsCounterTest()
        {
            var notificationCounters = _shoppingCartService.GetAllItemsInCart().Count();
            return notificationCounters;
        }

        [HttpPost]
        public JsonResult AddToWishlist(int id)
        {
            // get book
            var getBookById = _bookService.GetBookById(id);

            var CheckIfExistsInWishlist = _wishlistService.GetWishlistByBookId(id);

            if (CheckIfExistsInWishlist == null)
            {
                // get logged in user id
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // get other data ids
                var bookId = getBookById.Id;
                var publisherId = getBookById.PublisherID;
                var authorId = getBookById.AuthorID;
                var categoryId = getBookById.CategoryID;

                // init wishlist obj
                var wishlist = new Wishlist
                {
                    UserId = userId,
                    BookId = bookId,
                    //PublisherId = publisherId,
                    AuthorId = authorId,
                    CategoryId = categoryId,
                    DateAdded = DateTime.Now
                };

                // add to wishlist
                _wishlistService.Add(wishlist);

                return new JsonResult(new { data = wishlist });
            }
            else
            {
                return new JsonResult(new { data = "" });
            }
        }

        [HttpPost]
        public IActionResult FullSearch(string searchString)
        {
            return RedirectToAction("FullDetailedSearch", "Search", new { searchedString = searchString });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Helper Methods

        #endregion
    }
}
