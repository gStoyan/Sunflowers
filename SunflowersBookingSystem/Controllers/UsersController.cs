namespace SunflowersBookingSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using SunflowersBookingSystem.Services.Helpers;
    using SunflowersBookingSystem.Services.Models;
    using SunflowersBookingSystem.Services.Users.Interfaces;
    using SunflowersBookingSystem.Web.Helpers;

    [Authorize]
    [ApiController]
    [Route("api/v/[controller]")]
    public class UsersController : Controller
    {
        private IUserService _userService;
        private readonly AppSettings _appSettings;
        private readonly ILogger _logger;

        public UsersController(IUserService userService, IOptions<AppSettings> appSettings, ILogger<UsersController> logger)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            _logger.LogInformation(MyLogEvents.GetItem, $"{response.FirstName} authenticated");
            return Ok(response);

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            _userService.Register(model);
            _logger.LogInformation(MyLogEvents.InsertItem, $"{model.FirstName} user registered.");
            return Ok(new { message = "Registration successful" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
