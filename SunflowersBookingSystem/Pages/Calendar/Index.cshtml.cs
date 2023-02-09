namespace SunflowersBookingSystem.Web.Pages.Calendar
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using SunflowersBookingSystem.Services.Extensions;
    using SunflowersBookingSystem.Services.Mailing.Interfaces;
    using SunflowersBookingSystem.Services.Models.Reservations;
    using SunflowersBookingSystem.Services.Reservations;
    using SunflowersBookingSystem.Web.Models.Calendar;

    public class IndexModel : PageModel
    {
        private IReservationServices _reservationServices;

        private readonly IEmailSenderServices _emailSenderServices;
        public IndexModel(IReservationServices reservationServices, IEmailSenderServices emailSenderServices)
        {
            _reservationServices = reservationServices;
            _emailSenderServices = emailSenderServices;
        }
        public void OnGet(int month)
        {
            Days = GetDaysWithReservations(month);
        }


        public List<Day> Days { get; set; } = new List<Day>();

        [BindProperty]
        public int Month { get; set; }

        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime EndDate { get; set; }

        [BindProperty]
        public DateTime ArriveTime { get; set; }

        [BindProperty]
        public string? Comment { get; set; }


        public IActionResult OnPost()
        {
            string message = string.Empty;
            var userId = int.Parse(HttpContext.User.Identities.First().Claims.First(c => c.Type == "UserId").Value);
            var userEmail = HttpContext.User.Identities.First().Claims.First(c => c.Type == "Email").Value;
            var reservationDto = new ReservationDto()
            {
                ArriveTime = ArriveTime,
                Comment = Comment,
                EndDate = EndDate,
                StartDate = StartDate,
                UserId = userId
            };
            var days = GetDaysWithReservations(Month);

            //Loop through the days in the month to see if there are free rooms for the given reservation
            foreach (var day in days)
            {
                if (day.Date.IsBetween(reservationDto.StartDate, reservationDto.EndDate) && day.State.FreeRooms <= 0)
                {
                    return new RedirectToPageResult("/InformationPage", new { message = Constants.NoFreeRooms });
                }
            }

            _reservationServices.Create(reservationDto);
            _emailSenderServices.SendReservationConfirmationEmail(userEmail, reservationDto.StartDate, reservationDto.EndDate);
            return new RedirectToPageResult("/InformationPage", new { message = Constants.SuccessfullReservation });

        }

        private List<Day> GetDaysWithReservations(int month)
        {
            var days = new List<Day>();
            var reservations = _reservationServices
                .GetAll()
                .Where(x => x.StartDate.Month == month || x.EndDate.Month == month);


            // Loop from the first day of the month until we hit the next month, moving forward a day at a time
            for (var date = new DateTime(DateTime.Now.Year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                var day = new Day(date);
                var reservationsCount = reservations
                    .Where(d => date.IsBetween(d.StartDate, d.EndDate))
                    .Count();
                day.ReserveRooms(reservationsCount);
                //call stateChangeCheck
                day.ReserveRooms(0);

                days.Add(day);
            }

            return days;
        }
    }
}
