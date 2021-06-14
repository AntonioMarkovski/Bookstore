namespace Bookstore.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Bookstore.Entities;
    using Bookstore.Models;
    using Bookstore.Service.Interfaces;

    public class WishlistController : Controller
    {
        private readonly IWishlistService _wishlistService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBookService _bookService;
        private readonly IShoppingCartService _shoppingCartService;

        public WishlistController(
            IWishlistService wishlistService,
            IHttpContextAccessor httpContextAccessor,
            IBookService bookService,
            IShoppingCartService shoppingCartService)
        {
            _wishlistService = wishlistService;
            _httpContextAccessor = httpContextAccessor;
            _bookService = bookService;
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            // init new array of books
            List<Book> AllBookListFromWishlistByLoggedInUser = new List<Book>();
            var TotalPriceCount = 0.0;

            // get logged in user id
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var wishlists = _wishlistService.GetAllWishlistByUserId(userId);

            foreach (var item in wishlists)
            {
                var book = _bookService.GetBookById(item.BookId);
                if (book != null)
                {
                    AllBookListFromWishlistByLoggedInUser.Add(book);
                }
            }

            TotalPriceCount = Math.Round(AllBookListFromWishlistByLoggedInUser.Sum(x => x.Price), 2);

            // init viewmodel
            var bookViewModel = new BookViewModel();
            bookViewModel.AllBooksFromWishlistByLoggedInUser = AllBookListFromWishlistByLoggedInUser;
            bookViewModel.WishlistTotalPrice = TotalPriceCount;

            return View(bookViewModel);
        }

        public IActionResult Details(int id)
        {
            var book = _bookService.GetBookById(id);
            return View(book);
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            var getBook = _bookService.GetBookById(Id);

            _wishlistService.DeleteByBookId(Id);

            return new JsonResult(new { data = getBook, url = Url.Action("Index", "Wishlist") });
        }

        public JsonResult AddToCartFromWishlist(List<string> bookIds)
        {
            // add to temporary list
            List<string> bookIds_temp = bookIds;
            // get all book ids from bookIds / wishlist
            // and add to shopping cart table
            foreach (var book in bookIds_temp)
            {
                var getBook = _bookService.GetBookById(int.Parse(book));

                // get logged in user id
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // get other data ids
                var bookId = getBook.Id;

                // init shopping cart obj
                var shoppingCart = new ShoppingCart
                {
                    UserId = userId,
                    BookId = bookId,
                    Price = getBook.Price,
                    DateAdded = DateTime.Now
                };

                // add single book from wishlist to shopping cart
                _shoppingCartService.Add(shoppingCart);
            }

            // remove all selected items from wishlist
            foreach (var selectedItem in bookIds)
            {
                _wishlistService.DeleteByBookId(int.Parse(selectedItem));
            }

            return new JsonResult(new { data = "" });
        }

        public IActionResult GoToCart()
        {
            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
