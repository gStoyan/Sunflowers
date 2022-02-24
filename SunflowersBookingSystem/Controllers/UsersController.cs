namespace SunflowersBookingSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SunflowersBookingSystem.Data.Models;

    [ApiController]
    [Route("api/v/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        // GET: UsersController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            var result = await userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok(user);
        }

    }
}
