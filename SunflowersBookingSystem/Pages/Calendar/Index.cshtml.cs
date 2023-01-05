namespace SunflowersBookingSystem.Web.Pages.Calendar
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using SunflowersBookingSystem.Services.Extensions;
    using SunflowersBookingSystem.Services.Models.Reservations;
    using SunflowersBookingSystem.Services.Reservations;
    using SunflowersBookingSystem.Web.Models.Calendar;

    public class IndexModel : PageModel
    {
        private IReservationServices _reservationServices;
        public IndexModel(IReservationServices reservationServices)
        {
            _reservationServices = reservationServices;
        }
        public void OnGet(int month)
        {
            Days = GetDaysWithReservations(month);
        }

        public List<Day> Days { get; set; } = new List<Day>();
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
            var userId = int.Parse(HttpContext.User.Identities.First().Claims.First(c => c.Type == "UserId").Value);
            var reservationDto = new ReservationDto()
            {
                ArriveTime = ArriveTime,
                Comment = Comment,
                EndDate = EndDate,
                StartDate = StartDate,
                UserId = userId
            };

            _reservationServices.Create(reservationDto);


            //_logger.LogInformation(MyLogEvents.GetItem,
            //$"User with Id: {userId} created a reservation from {model.StartDate} untill {model.EndDate}");

            return new RedirectToPageResult("/About");

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
                var reservationsCount = reservations.Where(d => date.IsBetween(d.StartDate, d.EndDate)).Count();
                day.ReserveRooms(reservationsCount);

                days.Add(day);
            }

            return days;
        }
    }
}
