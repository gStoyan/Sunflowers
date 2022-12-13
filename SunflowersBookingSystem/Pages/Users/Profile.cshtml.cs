using Microsoft.AspNetCore.Mvc.RazorPages;
using SunflowersBookingSystem.Data.Models;

namespace SunflowersBookingSystem.Web.Pages.Users
{
    public class ProfileModel : PageModel
    {

        public void OnGet()
        {
        }

        public User LoggedUser { get; set; }
    }
}
