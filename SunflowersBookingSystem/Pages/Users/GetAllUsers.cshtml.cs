using Microsoft.AspNetCore.Mvc.RazorPages;
using SunflowersBookingSystem.Data.Models;

namespace SunflowersBookingSystem.Web.Pages
{
    public class GetAllUsersModel : PageModel
    {
        public void OnGet(IEnumerable<User> users)
        {
            this.Users = users;

        }
        public IEnumerable<User> Users { get; set; }
    }
}
