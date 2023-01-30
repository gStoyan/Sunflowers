namespace SunflowersBookingSystem.Web
{
    public static class Constants
    {
        public const int MaxRooms = 7;

        public const string SuccessfullReservation = "Congratulations!" +
            " Your reservation has been successfully created. We look forward to welcoming you and providing you with an exceptional experience." +
            " If you have any further questions or concerns, please don't hesitate to reach out to us. Thank you for choosing us!";

        public const string NoFreeRooms = "We apologize for the inconvenience, but all of our rooms on this date are booked. " +
            "We would be happy to place you on a waitlist for any cancellations or to assist you in finding alternative accommodations. " +
            "Please contact us for more information or to be added to the waitlist. Thank you for considering us.";

        public const string CancelledReservation = "Thank you for letting us know about your cancellation. " +
            "We have processed your request and your reservation has been successfully cancelled." +
            " If you have any questions or concerns please don’t hesitate to reach out to us. We hope to have the opportunity to serve you in the future.";
    }
}
