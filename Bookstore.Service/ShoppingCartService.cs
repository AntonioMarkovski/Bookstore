namespace Bookstore.Service
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    using Bookstore.Repository.Interfaces;
    using Bookstore.Entities;
    using Bookstore.Service.Interfaces;

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IWishlistRepository _wishlistRepository;
        private UserManager<IdentityUser> _userManager;

        public ShoppingCartService(
            IShoppingCartRepository shoppingCartRepository, 
            IBookRepository bookRepository, 
            IWishlistRepository wishlistRepository, 
            UserManager<IdentityUser> userManager)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _bookRepository = bookRepository;
            _wishlistRepository = wishlistRepository;
            _userManager = userManager;
        }

        public void Add(ShoppingCart shoppingCart)
        {
            _shoppingCartRepository.Add(shoppingCart);
        }

        public void Delete(int id)
        {
            _shoppingCartRepository.Delete(id);
        }

        public void DeleteByBookId(int bookID)
        {
            _shoppingCartRepository.DeleteByBookId(bookID);
        }

        public IEnumerable<ShoppingCart> GetAllItemsInCart()
        {
            var result = _shoppingCartRepository.GetAllItemsInCart();
            return result;
        }

        public IEnumerable<ShoppingCart> GetAllItemsInCartByUserId(string userId)
        {
            var result = _shoppingCartRepository.GetAllItemsInCartByUserId(userId);
            return result;
        }

        public ShoppingCart GetShoppingCartById(int id)
        {
            var result = _shoppingCartRepository.GetShoppingCartById(id);
            return result;
        }
    }
}
