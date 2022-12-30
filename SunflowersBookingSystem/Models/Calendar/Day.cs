namespace SunflowersBookingSystem.Web.Models.Calendar
{
    using SunflowersBookingSystem.Web.Models.Calendar.States;

    public class Day
    {
        private State _state;
        private DateTime _date;

        public Day(DateTime date)
        {
            _date = date;
            _state = new EmptyState(0, this);
            _state.FreeRooms = Constants.MaxRooms - _state.ReservedRooms;
        }

        public State State
        {
            get { return _state; }
            set { _state = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public void ReserveRooms(int roomsCount)
        {
            _state.ReserveRooms(roomsCount);
            _state.FreeRooms = Constants.MaxRooms - _state.ReservedRooms;
        }

        public void CancelReservation(int roomsCount)
        {
            _state.CancelReservation(roomsCount);
            _state.FreeRooms = Constants.MaxRooms - _state.ReservedRooms;
        }
    }
}
