using Microsoft.AspNetCore.Mvc.RazorPages;
using SunflowersBookingSystem.Services.Extensions;
using SunflowersBookingSystem.Services.Reservations;
using SunflowersBookingSystem.Web.Models.Calendar;

namespace SunflowersBookingSystem.Web.Pages.Calendar
{
    public class CalendarModel : PageModel
    {
        private IReservationServices _reservationServices;

        public CalendarModel(IReservationServices reservationServices)
        {
            _reservationServices = reservationServices;
        }
        public void OnGet(int month)
        {

            if (month == 0)
            {
                Month = 6;
            }
            else
            {
                Month = month;
            }
            Days = GetDaysWithReservations();
        }

        public List<Day> Days { get; set; }
        public int Month { get; set; }
        public int Room { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ArriveTime { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }

        private List<Day> GetDaysWithReservations()
        {
            var days = new List<Day>();
            var reservations = _reservationServices
                .GetAll()
                .Where(x => x.StartDate.Month == Month || x.EndDate.Month == Month);


            // Loop from the first day of the month until we hit the next month, moving forward a day at a time
            for (var date = new DateTime(DateTime.Now.Year, Month, 1); date.Month == Month; date = date.AddDays(1))
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
