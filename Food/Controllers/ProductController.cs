using Food.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Food.Controllers
{
    public class ProductController : Controller
    {
        private readonly FoodContext _context;
        public ProductController(FoodContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.BProducts == null)
            {
                return NotFound();
            }

            var product = await _context.BProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            var productReviews = await _context.BProductReviews
                .Where(i => i.ProductId == id)
                .ToListAsync();

            ViewBag.Product = product;
            ViewBag.ProductReviews = productReviews;

            return View(product); // Trả về view với model sản phẩm
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, string phone, string email, string message, int star, string ProductId)
        {
            try
            {
                var productReview = new BProductReview
                {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Detail = message,
                    Star = star, // Lưu đánh giá sao
                    ProductId = ProductId,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                _context.Add(productReview);
                await _context.SaveChangesAsync();

                return Json(new { status = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(new { status = false, error = ex.Message });
            }
        }

    }
}