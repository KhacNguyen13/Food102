using Microsoft.AspNetCore.Mvc;
using Food.Models;
using Microsoft.EntityFrameworkCore;

namespace Food.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly FoodContext _context;

        public ProductViewComponent(FoodContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IViewComponentResult> InvokeAsync(string? categoryId = null)
        {
            // Query products based on CategoryId if provided
            IQueryable<BProduct> query = _context.BProducts;

            if (!string.IsNullOrEmpty(categoryId))
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }

            // Additional filtering logic, such as active or new products
            var items = await query
                .Where(p => p.IsNew == true) // Example condition; adjust as needed
                .OrderBy(p => p.CreatedAt ?? DateTime.MinValue) // Null-safe sorting
                .ToListAsync();

            return View(items); // Return the view with the filtered products
        }
    }
}
