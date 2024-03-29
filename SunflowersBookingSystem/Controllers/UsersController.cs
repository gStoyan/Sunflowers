﻿namespace SunflowersBookingSystem.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using SunflowersBookingSystem.Services.Helpers;
    using SunflowersBookingSystem.Services.Reservations;
    using SunflowersBookingSystem.Services.Users;
    using SunflowersBookingSystem.Web.Attributes;
    using SunflowersBookingSystem.Web.Models;
    using SunflowersBookingSystem.Web.Utilities;

    [CustomAuthorize]
    [ApiController]
    [Route("api/v/[controller]")]
    public class UsersController : Controller
    {
        private IUserService _userService;
        private IReservationServices _reservationServices;
        private readonly AppSettings _appSettings;
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService,
            IReservationServices reservationServices,
            IOptions<AppSettings> appSettings,
            ILogger<UsersController> logger,
            IWebHostEnvironment hostingEnvironment,
            IMapper mapper)
        {
            _userService = userService;
            _reservationServices = reservationServices;
            _appSettings = appSettings.Value;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }

        [CustomAllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromForm] AuthenticateViewModel authenticateModel)
        {

            var response = _userService.Authenticate(authenticateModel.ConvertToDto());
            _logger.LogInformation(MyLogEvents.GetItem, $"{response.Email} authenticated");

            Response.Cookies.Append("Bearer", response.Token, new CookieOptions { MaxAge = TimeSpan.FromDays(1) });
            Response.Cookies.Append("User", response.Email, new CookieOptions { MaxAge = TimeSpan.FromDays(1) });
            response.Token = null;

            return new RedirectToPageResult("/Users/Profile");
        }

        [CustomAllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromForm] RegisterViewModel registerModel)
        {
            _userService.Register(registerModel.ConvertToDto());

            _logger.LogInformation(MyLogEvents.InsertItem, $"{registerModel.FirstName} user registered.");
            return new RedirectToPageResult("/Users/Login");
        }

        [HttpGet]
        public IActionResult Profile(int id)
        {
            _logger.LogInformation(MyLogEvents.GetItem,
                $"User with Id {HttpContext.User.Identities.First().Claims.First(c => c.Type == "UserId").Value} entered his profile page");
            return new RedirectToPageResult("/Users/Profile");
        }

        [HttpGet("update")]
        public IActionResult Update(string id) => new RedirectToPageResult("/Users/EditProfile");

        [HttpPost("UpdatePost")]
        public async Task<IActionResult> UpdatePost([FromForm] UpdateProfileViewModel model)
        {
            if (model.ProfilePicture != null)
            {
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "images/", model.ProfilePicture.FileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await model.ProfilePicture.CopyToAsync(stream);
                    stream.Close();
                }
            }

            var response = await _userService.UpdateAsync(model.ConvertToDto());
            _logger.LogInformation(MyLogEvents.UpdateItem, $"{response.FirstName} updated his profile data.");
            return new RedirectToPageResult("/InformationPage", new { message = Constants.SuccessfullProfileEdit });
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
