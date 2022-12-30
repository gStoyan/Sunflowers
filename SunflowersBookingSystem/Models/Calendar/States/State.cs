namespace SunflowersBookingSystem.Web.Models.Calendar.States
{
    public abstract class State
    {
        protected Day day;

        protected int reservedRooms;
        protected int lowerLimit;
        protected int upperLimit;
        protected int freeRomms;

        public Day Day
        {
            get { return day; }
            set { day = value; }
        }

        public int ReservedRooms
        {
            get { return reservedRooms; }
            set { reservedRooms = value; }
        }

        public int FreeRooms
        {
            get { return freeRomms; }
            set { freeRomms = value; }
        }

        public abstract void ReserveRooms(int roomsCount);
        public abstract void CancelReservation(int roomsCount);
    }
}
