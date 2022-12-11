namespace SunflowersBookingSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using SunflowersBookingSystem.Services.Helpers;
    using SunflowersBookingSystem.Services.Users.Interfaces;
    using SunflowersBookingSystem.Web.Attributes;
    using SunflowersBookingSystem.Web.Helpers;
    using SunflowersBookingSystem.Web.Models;

    [CustomAuthorize]
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

        [CustomAllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromForm] AuthenticateViewModel authenticateModel)
        {

            var response = _userService.Authenticate(authenticateModel.ConvertToDto());
            _logger.LogInformation(MyLogEvents.GetItem, $"{response.Email} authenticated");
            Response.Cookies.Append("Bearer", response.Token);
            Response.Cookies.Append("User", response.Email);
            return new RedirectToPageResult("/Users/Profile");

        }

        [CustomAllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromForm] RegisterViewModel registerModel)
        {
            _userService.Register(registerModel.ConvertToDto());

            _logger.LogInformation(MyLogEvents.InsertItem, $"{registerModel.FirstName} user registered.");
            return new RedirectToPageResult("/About");
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();

            _logger.LogInformation(MyLogEvents.GetItem, "Get all users.");
            return new RedirectToPageResult("/Users/GetAllUsers", users);
        }

        [HttpGet("LogOut")]
        public IActionResult LogOut()
        {
            Response.Cookies.Delete("Bearer");
            var username = Request.Cookies["User"];
            Response.Cookies.Delete("User");
            _logger.LogInformation(MyLogEvents.DeleteItem, $"{username} logged out. Deleted cookies.");
            return new RedirectToPageResult("/Index");
        }
    }
}
