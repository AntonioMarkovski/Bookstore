namespace Bookstore.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using MoreLinq;
    using Bookstore.Data;
    using Bookstore.Entities;
    using Bookstore.Repository.Interfaces;

    public class WishlistRepository : IWishlistRepository
    {
        private readonly DataContext _context;

        public WishlistRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Wishlist wishlist)
        {
            _context.Wishlists.Add(wishlist);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var wishlist = GetWishlistById(id);
            _context.Wishlists.Remove(wishlist);
            _context.SaveChanges();
        }

        public void DeleteByBookId(int Id)
        {
            // TODO: 
            var wishlist = GetWishlistByBookId(Id);
            _context.Wishlists.Remove(wishlist);
            _context.SaveChanges();
        }

        public void Edit(Wishlist wishlist)
        {
            _context.Wishlists.Update(wishlist);
            _context.SaveChanges();
        }

        // Important
        public IEnumerable<Wishlist> GetAllWishlistByUserId(string userId)
        {
            // Use of MoreLinq Library from NuGet Package (DistinctBy)
            var result = _context.Wishlists.AsEnumerable().Where(x => x.UserId == userId).DistinctBy(x => x.BookId);
            return result;
        }

        public IEnumerable<Wishlist> GetAllWishlists()
        {
            var result = _context.Wishlists.AsEnumerable();
            return result;
        }

        public Wishlist GetWishlistById(int id)
        {
            var result = _context.Wishlists.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public Wishlist GetWishlistByBookId(int bookID)
        {
            var result = _context.Wishlists.FirstOrDefault(x => x.BookId == bookID);
            return result;
        }

    }
}
