using Food.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Food.ViewComponents
{
    public class ContactViewComponent : ViewComponent
    {
        private readonly FoodContext _Context;

        public ContactViewComponent(FoodContext context)
        {
            _Context = context;
        }

        public IViewComponentResult Invoke()
        {
            // Lấy danh sách các liên hệ hoạt động từ cơ sở dữ liệu
            var contacts = _Context.BContacts
                .Where(c => c.IsActive == true)
                .OrderByDescending(c => c.CreatedOn)
                .ToList();

            return View(contacts); // Trả về view với danh sách liên hệ
        }
    }
}
