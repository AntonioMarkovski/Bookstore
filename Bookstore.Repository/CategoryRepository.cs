namespace Bookstore.Repository
{
    using Bookstore.Data;
    using Bookstore.Entities;
    using Bookstore.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            Category category = GetCategoryById(categoryId);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void EditCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var result = _context.Categories.AsEnumerable();
            return result;
        }

        public Category GetCategoryById(int id)
        {
            var result = _context.Categories.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
