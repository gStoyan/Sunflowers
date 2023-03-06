namespace SunflowersBookingSystem.Web
{
    public static class Constants
    {
        public const int MaxRooms = 7;

        public const string SuccessfullReservation = "<p>Congratulations!</p>" +
            " <p>Your reservation has been successfully created. We look forward to welcoming you and providing you with an exceptional experience.</p>" +
            " <p>We have send a confirmation message to your mailbox</p>" +
            " <p>If you have any further questions or concerns, please don't hesitate to reach out to us. Thank you for choosing us!</p>";

        public const string NoFreeRooms = "<p>We apologize for the inconvenience, but all of our rooms on this date are booked. </p>" +
            "<p>We would be happy to place you on a waitlist for any cancellations or to assist you in finding alternative accommodations. </p>" +
            "<p>Please contact us for more information or to be added to the waitlist. Thank you for considering us.</p>";

        public const string CancelledReservation = "<p>Thank you for letting us know about your cancellation. </p>" +
            "<p>We have processed your request and your reservation has been successfully cancelled.</p>" +
            " <p>If you have any questions or concerns please don’t hesitate to reach out to us. We hope to have the opportunity to serve you in the future.</p>";
    }
}
