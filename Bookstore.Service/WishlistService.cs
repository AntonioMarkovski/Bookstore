namespace Bookstore.Service
{
    using System.Collections.Generic;
    using Bookstore.Entities;
    using Bookstore.Repository.Interfaces;
    using Bookstore.Service.Interfaces;

    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _wishlistRepository;

        public WishlistService(IWishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }

        public void Add(Wishlist wishlist)
        {
            _wishlistRepository.Add(wishlist);
        }

        public void Delete(int id)
        {
            _wishlistRepository.Delete(id);
        }

        public void DeleteByBookId(int bookID)
        {
            _wishlistRepository.DeleteByBookId(bookID);
        }

        public void Edit(Wishlist wishlist)
        {
            _wishlistRepository.Edit(wishlist);
        }

        public IEnumerable<Wishlist> GetAllWishlistByUserId(string userId)
        {
            var result = _wishlistRepository.GetAllWishlistByUserId(userId);
            return result;
        }

        public IEnumerable<Wishlist> GetAllWishlists()
        {
            var result = _wishlistRepository.GetAllWishlists();
            return result;
        }

        public Wishlist GetWishlistByBookId(int bookID)
        {
            var result = _wishlistRepository.GetWishlistByBookId(bookID);
            return result;
        }

        public Wishlist GetWishlistById(int id)
        {
            var result = _wishlistRepository.GetWishlistById(id);
            return result;
        }
    }
}
