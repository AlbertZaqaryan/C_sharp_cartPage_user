using LoginReg.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using LoginReg.Models;

namespace LoginReg.Controllers
{
    public class CartController : Controller
    {
		private readonly ApplicationDbContext _context;
		public CartController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
        {
			string user_Id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
			var res = _context.carts.AsQueryable();
			if (user_Id != null)
			{
				res = _context.carts.Where(i => i.UserId == user_Id);

			}
			var item = res.ToList();
			return View(item);
        }

		public IActionResult Add(int product_id) {
            string user_Id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
			var prodIsExist = _context.carts.SingleOrDefault(i => i.ProductId == product_id);
			if (prodIsExist != null)
			{

				prodIsExist.Count++;
			}
			else {
				var newproduct = new Cart { ProductId = product_id, Count = 1, UserId = user_Id };
				_context.carts.Add(newproduct);
			}
			_context.SaveChanges();

			return RedirectToAction("Index");

        }
    }
}
