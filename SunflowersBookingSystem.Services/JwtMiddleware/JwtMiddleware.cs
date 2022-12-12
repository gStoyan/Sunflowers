namespace SunflowersBookingSystem.Services.JwtMiddleware
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using SunflowersBookingSystem.Services.Users.Interfaces;
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            //var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var token = context.Request.Cookies["Bearer"];
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetById(userId.Value);

                var identity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim("UserId", "1", ClaimValueTypes.Integer32),
                    new Claim(ClaimTypes.Role, "user")
                }, "Custom");
                context.User = new ClaimsPrincipal(identity);
            }


            await _next(context);
        }
    }
}
