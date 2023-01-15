namespace SunflowersBookingSystem.Web.Models.Calendar.States
{
    public class FullState : State
    {
        public FullState(State state) :
            this(state.ReservedRooms, state.Day)
        {
        }
        public FullState(int reservedRooms, Day day)
        {
            this.reservedRooms = reservedRooms;
            this.Day = day;
            Initialize();
        }

        private void Initialize()
        {
            lowerLimit = 5;
            upperLimit = 7;
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
            if (reservedRooms < 2)
            {
                day.State = new EmptyState(this);
            }

            else if (reservedRooms < lowerLimit)
            {
                day.State = new HalfFullState(this);
            }
        }
    }
}
