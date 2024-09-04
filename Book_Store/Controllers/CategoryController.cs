using Book_Store.Data;
using Book_Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> CategoryList = _context.Categories.ToList();
            return View(CategoryList);
        }
    }
}
