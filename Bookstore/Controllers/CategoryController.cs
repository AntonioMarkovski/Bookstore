namespace Bookstore.Controllers
{
    using Bookstore.Entities;
    using Bookstore.Service.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var allCategories = _categoryService.GetAllCategories();
            return View(allCategories);
        }

        [HttpPost]
        public JsonResult CreateCategoryAJAX(Category category)
        {
            if (category != null)
            {
                if (!string.IsNullOrEmpty(category.Name))
                {
                    _categoryService.Add(category);
                    return Json(new { data = category });
                }
                else
                {
                    return Json(new { data = "" });
                }
            }
            else
            {
                return Json(new { data = "" });
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _categoryService.Add(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _categoryService.Edit(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _categoryService.Delete(category.Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
