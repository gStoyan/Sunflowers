using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SunflowersBookingSystem.Services.Models.Users;
using SunflowersBookingSystem.Services.Users;

namespace SunflowersBookingSystem.Web.Pages.Users
{
    public class ProfileModel : PageModel
    {
        private readonly IUserService _userServices;
        private readonly IMapper _mapper;

        public ProfileModel(IUserService userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        public void OnGet(int id)
        {
            var user = _userServices.GetById(id);
            LoggedUser = _mapper.Map<UserDto>(user);
        }

        public UserDto LoggedUser { get; set; }
    }
}
