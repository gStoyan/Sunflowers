using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SunflowersBookingSystem.Services.Models.Users;
using SunflowersBookingSystem.Services.Reservations;
using SunflowersBookingSystem.Services.Users;
using SunflowersBookingSystem.Web.Utilities;

namespace SunflowersBookingSystem.Web.Pages.Users
{
    public class ProfileModel : PageModel
    {
        private readonly IReservationServices _reservationServices;
        private readonly ILogger _logger;

        private readonly IUserService _userServices;
        private readonly IMapper _mapper;

        public ProfileModel(IUserService userServices, IMapper mapper, ILogger<ProfileModel> logger, IReservationServices reservationServices)
        {
            _userServices = userServices;
            _mapper = mapper;
            _logger = logger;
            _reservationServices = reservationServices;
        }

        public void OnGet()
        {
            var id = int.Parse(HttpContext.User.Identities.First().Claims.First(c => c.Type == "UserId").Value);
            var user = _userServices.GetById(id);
            LoggedUser = _mapper.Map<UserDto>(user);
        }

        public UserDto LoggedUser { get; set; }


        [BindProperty]
        public int ReservationId { get; set; }

        public IActionResult OnPost()
        {
            int reservationId = ReservationId;
            _reservationServices.Delete(reservationId);
            _logger.LogInformation(MyLogEvents.DeleteItem,
                $"User with Id {HttpContext.User.Identities.First().Claims.First(c => c.Type == "UserId").Value} cancelled reservation with id {reservationId}");

            return new RedirectToPageResult("/InformationPage", new { message = Constants.CancelledReservation });
        }
    }
}
