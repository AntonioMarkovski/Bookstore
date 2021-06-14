namespace Bookstore.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Bookstore.Service.Interfaces;
    using Bookstore.Entities;
    using System.Security.Claims;
    using Bookstore.Models;

    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IWishlistService _wishlistService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrderService _orderService;

        public ShoppingCartController(
            IShoppingCartService shoppingCartService,
            IBookService bookService,
            IAuthorService authorService,
            IWishlistService wishlistService,
            IHttpContextAccessor httpContextAccessor,
            IOrderService orderService)
        {
            _shoppingCartService = shoppingCartService;
            _bookService = bookService;
            _authorService = authorService;
            _wishlistService = wishlistService;
            _httpContextAccessor = httpContextAccessor;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            // init new array of books
            List<Book> AllBookListFromCartByLoggedInUser = new List<Book>();
            double TotalPriceCount = 0.0;
            double TotalShipping = 0.0;
            int NotificationCounter = 0;
            double TotalWeightCount = 0.0;

            // get logged in user id
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var itemsInCart = _shoppingCartService.GetAllItemsInCartByUserId(userId);
            // convert all cart items to list of books
            AllBookListFromCartByLoggedInUser = _orderService.ConvertAllItemsInCartToList(itemsInCart);
            // calculate total price of books in cart
            TotalPriceCount = _orderService.CalculateTotalPrice(TotalShipping, AllBookListFromCartByLoggedInUser);
            // notification counter for items in cart
            NotificationCounter = _shoppingCartService.GetAllItemsInCart().Count();
            // calculate total weight
            TotalWeightCount = _orderService.CalculateTotalWeight(AllBookListFromCartByLoggedInUser);

            // convert all cart items to list of books
            AllBookListFromCartByLoggedInUser = _orderService.ConvertAllItemsInCartToList(itemsInCart);

            TotalPriceCount = TotalShipping + Math.Round(AllBookListFromCartByLoggedInUser.Sum(x => x.Price), 2);
            NotificationCounter = _shoppingCartService.GetAllItemsInCart().Count();

            var shopCartViewModel = new ShopCartViewModel()
            {
                AllBooksAddedToCartByLoggedInUser = AllBookListFromCartByLoggedInUser,
                AddToCartTotalCounter = NotificationCounter
            };

            var subTotal = _orderService.CalculateTotalShipping(TotalWeightCount, TotalPriceCount).Item1;
            var shippingTotal = _orderService.CalculateTotalShipping(TotalWeightCount, TotalPriceCount).Item2;
            var totalPrice = _orderService.CalculateTotalShipping(TotalWeightCount, TotalPriceCount).Item3;

            shopCartViewModel.TotalPrice = totalPrice;
            shopCartViewModel.SubTotal = subTotal;
            shopCartViewModel.ShippingTotal = shippingTotal;

            ViewData["Counter"] = NotificationCounter;

            return View(shopCartViewModel);
        }

        public JsonResult AddToCart(int id)
        {
            // get book
            var getBookById = _bookService.GetBookById(id);
            // get logged in user id
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            // get other data ids
            var bookId = getBookById.Id;
            var publisherId = getBookById.PublisherID;
            var authorId = getBookById.AuthorID;
            var categoryId = getBookById.CategoryID;

            // init shopping cart obj
            var shoppingCart = new ShoppingCart
            {
                UserId = userId,
                BookId = bookId,
                Price = getBookById.Price,
                DateAdded = DateTime.Now
            };

            // add to shopping cart
            _shoppingCartService.Add(shoppingCart);

            return new JsonResult(new { data = shoppingCart });
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            var getBook = _bookService.GetBookById(Id);

            _shoppingCartService.DeleteByBookId(Id);
            // ~/ShoppingCart/Index
            return new JsonResult(new { data = getBook, url = Url.Action("Index", "ShoppingCart") });
        }

        public IActionResult Buy()
        {
            return RedirectToAction("Create", "Order");
        }

    }
}
