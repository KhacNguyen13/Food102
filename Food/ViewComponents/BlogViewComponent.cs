using Microsoft.AspNetCore.Mvc;
using Food.Models;
using Microsoft.EntityFrameworkCore;

namespace Food.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly FoodContext _context;

        public BlogViewComponent(FoodContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.BBlogs.Where(m => m.IsActive.HasValue && m.IsActive.Value) // Null-safe IsActive check
                .OrderBy(m => m.CreatedAt) // Sort by creation date for better organization
                .ToListAsync();

            return View(items); // Pass the data to the corresponding view
        }
    }
}
