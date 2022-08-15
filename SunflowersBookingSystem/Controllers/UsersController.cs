namespace SunflowersBookingSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using SunflowersBookingSystem.Services.Helpers;
    using SunflowersBookingSystem.Services.Models;
    using SunflowersBookingSystem.Services.Users.Interfaces;
    using SunflowersBookingSystem.Web.Attributes;
    using SunflowersBookingSystem.Web.Helpers;
    using System.Net.Http.Headers;
    using System.Security.Claims;

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

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromForm] AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            _logger.LogInformation(MyLogEvents.GetItem, $"{response.FirstName} authenticated");
            Response.Cookies.Append("Bearer", response.Token);
            return new RedirectToPageResult("/Users/Profile");

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromForm] RegisterRequest model)
        {
            _userService.Register(model);

            _logger.LogInformation(MyLogEvents.InsertItem, $"{model.FirstName} user registered.");
            return new RedirectToPageResult("/About");
        }

        [HttpGet]
        [Route("/Users/GetAll")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();

            _logger.LogInformation(MyLogEvents.GetItem, "Get all users.");
            return new RedirectToPageResult("/Users/GetAllUsers", users);
        }

        [HttpGet]
        [Route("/LogOut")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return new RedirectToPageResult("Index");
        }
    }
}
