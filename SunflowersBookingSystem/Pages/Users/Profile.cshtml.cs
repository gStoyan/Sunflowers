using Microsoft.AspNetCore.Mvc.RazorPages;
using SunflowersBookingSystem.Data.Models;

namespace SunflowersBookingSystem.Web.Pages.Users
{
    public class ProfileModel : PageModel
    {

        public void OnGet(User user)
        {
            this.LoggedUser = user;
        }

        public User LoggedUser { get; set; }
    }
}
