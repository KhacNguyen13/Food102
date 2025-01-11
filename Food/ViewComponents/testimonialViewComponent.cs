using Food.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Food.ViewComponents
{
    public class testimonialViewComponent : ViewComponent
    {
        private readonly FoodContext _Context;

        public testimonialViewComponent(FoodContext Context)
        {
            _Context = Context;
        }

        public IViewComponentResult Invoke()
        {
            // Retrieve active contacts from the database
            var contacts = _Context.BContacts
                .Where(c => c.IsActive == true)
                .OrderByDescending(c => c.CreatedOn)
                .ToList();

            return View(contacts); // Pass the data to the Razor view
        }
    }
}
