using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SunflowersBookingSystem.Data.Models;

namespace SunflowersBookingSystem.Web.Pages
{
    public class GetAllUsersModel : PageModel
    {
        public IEnumerable<User> Users{ get; set; }
        public void OnGet(IEnumerable<User> users)
        {
            this.Users = users;

        }
    }
}
