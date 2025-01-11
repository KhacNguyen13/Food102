using Microsoft.AspNetCore.Mvc;
using Food.Models;
using Microsoft.EntityFrameworkCore;
using Food.Services;

public class MenuTopViewComponent : ViewComponent
{
    private readonly MenuService _menuService;

    public MenuTopViewComponent(MenuService menuService)
    {
        _menuService = menuService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        // Lấy danh sách menu cha
        var menus = await _menuService.GetParentMenusAsync();
        return View(menus);
    }
}

