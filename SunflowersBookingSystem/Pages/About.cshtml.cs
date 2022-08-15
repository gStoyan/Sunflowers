using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SunflowersBookingSystem.Web.Pages
{
    public class AboutModel : PageModel
    {

        public string Message { get; set; }
        public void OnGet()
        {
            Message = "Success";
        }
    }
}
