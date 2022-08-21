namespace SunflowersBookingSystem.Web.Attributes
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using SunflowersBookingSystem.Data.Models;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<CustomAllowAnonymous>().Any();
            if (allowAnonymous)
                return;

            // authorization
            var user = (User?)context.HttpContext.Items["User"];
            if (user == null)
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
