using LoginReg.Data;
using Microsoft.AspNetCore.Mvc;

namespace LoginReg.Controllers
{
	public class ProductController : Controller
	{
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
		{
            var res = _context.products.AsQueryable();
            if (id != null) {
                res = _context.products.Where(i => i.CategoryId == id);
            }
            var item = res.ToList();
            return View(item);
		}
	}
}
