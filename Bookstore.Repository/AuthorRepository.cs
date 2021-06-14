namespace Bookstore.Repository
{
    using Bookstore.Data;
    using Bookstore.Entities;
    using Bookstore.Repository.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
        
        public void DeleteAuthor(int authorId)
        {
            Author author = GetAuthorById(authorId);
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public void EditAuthor(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }  

        public IEnumerable<Author> GetAllAuthors()
        {
            var result = _context.Authors.AsEnumerable();
            return result;
        }

        public Author GetAuthorById(int id)
        {
            var result = _context.Authors.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
