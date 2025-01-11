using Food.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food.Controllers
{
    public class ContactController : Controller
    {
        private readonly FoodContext _context;
        public ContactController(FoodContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, string phone, string email, string message)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(message))
            {
                return Json(new { status = false, error = "Name and Message are required." });
            }

            try
            {
                var testimonial = new BTestimonial
                {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Message = message,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "System"
                };

                _context.Add(testimonial);
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
