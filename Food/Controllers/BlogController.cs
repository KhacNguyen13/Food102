using Food.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Controllers
{
    public class BlogController : Controller
    {
        private readonly FoodContext _context;
        public BlogController(FoodContext context)
        {
            _context = context;
        }
        [Route("/blog/{id}.html")]
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.BBlogs == null)
            {
                return NotFound();
            }
            var blog = await _context.BBlogs.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }
            var blogComments = await _context.BBlogComments
                .Where(i => i.BlogId == id).ToListAsync();

            ViewBag.Blog = blog;
            ViewBag.BlogComments = blogComments;
            return View(blog);  }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, string Phone, string Email, string message, string blogId)
        {
            try
            {
                 var blogComment = new BBlogComment
                {
                    Name = name,
                    Phone = Phone,
                    Email = Email,
                    Detail = message, 
                    BlogId = blogId, 
                    CreatedDate = DateTime.Now, 
                    IsActive = true
                 };
                _context.Add(blogComment);
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
