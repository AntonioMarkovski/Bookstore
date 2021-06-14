namespace Bookstore.Service.Interfaces
{
    using System.Collections.Generic;
    using Bookstore.Entities;

    public interface IWishlistService
    {
        void Add(Wishlist wishlist);
        void Edit(Wishlist wishlist);
        void Delete(int id);
        void DeleteByBookId(int bookID);
      
        Wishlist GetWishlistById(int id);
        Wishlist GetWishlistByBookId(int bookID);
        
        IEnumerable<Wishlist> GetAllWishlists();
        IEnumerable<Wishlist> GetAllWishlistByUserId(string userId);
    }
}
