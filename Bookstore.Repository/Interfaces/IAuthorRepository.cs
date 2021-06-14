namespace Bookstore.Repository.Interfaces
{
    using Bookstore.Entities;
    using System.Collections.Generic;

    public interface IAuthorRepository
    {
        void AddAuthor(Author author);
        void EditAuthor(Author author);
        void DeleteAuthor(int authorId);

        Author GetAuthorById(int id);

        IEnumerable<Author> GetAllAuthors();
    }
}
