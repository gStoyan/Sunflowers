using Microsoft.AspNetCore.Mvc.RazorPages;
using SunflowersBookingSystem.Services.Models.Users;

namespace SunflowersBookingSystem.Web.Pages.Users
{
    public class EditProfileModel : PageModel
    {
        public void OnGet(UserDto user)
        {
            this.LoggedUser = user;
        }

        public UserDto LoggedUser { get; set; }

    }
}
