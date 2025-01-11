using Food.Models;
using Microsoft.EntityFrameworkCore;

namespace Food.Services
{
    public class MenuService
    {
        private readonly FoodContext _context;
        public MenuService(FoodContext context)
        {
            _context = context;
        }
       
    public async Task<List<BMenu>> GetActiveMenusAsync()
        {
            return await _context.BMenus
                .Where(menu => menu.IsActive == true)
                .OrderBy(menu => menu.Position)
                .ToListAsync();
        }

        // Lấy menu cha
        public async Task<List<BMenu>> GetParentMenusAsync()
        {
            return await _context.BMenus
                .Where(menu => menu.IsActive == true && menu.Parent == null)
                .OrderBy(menu => menu.Position)
                .ToListAsync();
        }

        // Lấy menu con theo Parent ID
        public async Task<List<BMenu>> GetChildMenusAsync(string parentId)
        {
            return await _context.BMenus
                .Where(menu => menu.IsActive == true && menu.Parent == parentId)
                .OrderBy(menu => menu.Position)
                .ToListAsync();
        }
    }
}
