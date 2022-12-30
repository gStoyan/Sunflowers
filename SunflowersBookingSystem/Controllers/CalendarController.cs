namespace SunflowersBookingSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SunflowersBookingSystem.Services.Reservations;
    using SunflowersBookingSystem.Web.Attributes;
    using SunflowersBookingSystem.Web.Utilities;

    [CustomAuthorize]
    [ApiController]
    [Route("api/v/[controller]")]
    public class CalendarController : Controller
    {
        private ILogger _logger;
        private IReservationServices _reservationServices;

        public CalendarController(ILogger<CalendarController> logger, IReservationServices reservationServices)
        {
            _logger = logger;
            _reservationServices = reservationServices;
        }

        [HttpGet("Index")]
        public IActionResult Index(int month)
        {
            _logger.LogInformation(MyLogEvents.GetItem,
                $"User with Id: {HttpContext.User.Identities.First().Claims.First(c => c.Type == "UserId").Value} accessed calendar page");
            return new RedirectToPageResult("/Calendar/Index", new { month = month });
        }

        [HttpPost("CreateReservation")]
        public async Task<IActionResult> CreateReservation(Index model)
        {
            throw new NotImplementedException();
        }
    }
}
