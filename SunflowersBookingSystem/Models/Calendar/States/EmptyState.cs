namespace SunflowersBookingSystem.Web.Models.Calendar.States
{
    public class EmptyState : State
    {
        public EmptyState(State state)
        {
            this.reservedRooms = state.ReservedRooms;
            this.Day = state.Day;
            Initialize();
        }

        public EmptyState(int reservedRooms, Day day)
        {
            this.reservedRooms = reservedRooms;
            this.Day = day;
            Initialize();
        }

        private void Initialize()
        {
            lowerLimit = 0;
            upperLimit = 2;
        }

        public override void CancelReservation(int roomsCount)
        {
            reservedRooms -= roomsCount;
            StateChangeCheck();
        }

        public override void ReserveRooms(int roomsCount)
        {
            reservedRooms += roomsCount;
            Console.WriteLine("No reservations to cancel");
        }

        private void StateChangeCheck()
        {
            if (reservedRooms < upperLimit)
            {
                day.State = new HalfFullState(this);
            }
        }
    }
}
