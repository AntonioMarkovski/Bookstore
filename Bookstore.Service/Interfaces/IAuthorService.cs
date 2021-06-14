using Bookstore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Service.Interfaces
{
    public interface IAuthorService
    {
        void Add(Author author);
        void Edit(Author author);
        void Delete(int authorId);

        Author GetAuthorById(int id);

        IEnumerable<Author> GetAllAuthors();
    }
}
