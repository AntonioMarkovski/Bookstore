namespace Bookstore.Service.Interfaces
{
    using Bookstore.Entities;
    using System.Collections.Generic;

    public interface IShoppingCartService
    {
        void Add(ShoppingCart shoppingCart);
        void Delete(int id);
        void DeleteByBookId(int bookID);
        ShoppingCart GetShoppingCartById(int id);
        IEnumerable<ShoppingCart> GetAllItemsInCart();
        IEnumerable<ShoppingCart> GetAllItemsInCartByUserId(string userId);
    }
}
