namespace SunflowersBookingSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SunflowersBookingSystem.Web.Attributes;
    using SunflowersBookingSystem.Web.Utilities;

    [CustomAuthorize]
    [ApiController]
    [Route("api/v/[controller]")]
    public class CalendarController : Controller
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            //_logger.LogInformation(MyLogEvents.GetItem, "Get all users.");
            return new RedirectToPageResult("/Calendar/Index");
        }
    }
}
