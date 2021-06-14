namespace Bookstore.Repository.Interfaces
{
    using Bookstore.Entities;
    using System.Collections.Generic;

    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(int categoryId);

        Category GetCategoryById(int id);

        IEnumerable<Category> GetAllCategories();
    }
}
