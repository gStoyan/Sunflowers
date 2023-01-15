using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SunflowersBookingSystem.Web.Pages
{
    public class InformationPageModel : PageModel
    {
        public void OnGet(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
