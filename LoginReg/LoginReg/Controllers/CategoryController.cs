using LoginReg.Data;
using Microsoft.AspNetCore.Mvc;

namespace LoginReg.Controllers
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
            var result = _context.categories.ToList();
            return View(result);
        }
    }
}
