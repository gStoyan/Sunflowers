namespace SunflowersBookingSystem.Web.Models.Calendar.States
{
    public class HalfFullState : State
    {
        public HalfFullState(State state) :
            this(state.ReservedRooms, state.Day)
        {
        }
        public HalfFullState(int reservedRooms, Day day)
        {
            this.reservedRooms = reservedRooms;
            this.Day = day;
            Initialize();
        }

        private void Initialize()
        {
            lowerLimit = 2;
            upperLimit = 6;
        }

        public override void CancelReservation(int roomsCount)
        {
            reservedRooms -= roomsCount;
            StateChangeCheck();
        }

        public override void ReserveRooms(int roomsCount)
        {
            reservedRooms += roomsCount;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (reservedRooms > upperLimit)
            {
                day.State = new FullState(this);
            }

            if (reservedRooms < lowerLimit)
            {
                day.State = new EmptyState(this);
            }
        }
    }
}
