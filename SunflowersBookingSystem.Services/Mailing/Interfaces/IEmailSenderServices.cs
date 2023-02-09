namespace SunflowersBookingSystem.Services.Mailing.Interfaces
{
    using SunflowersBookingSystem.Services.Models.Mailing;

    public interface IEmailSenderServices
    {
        void SendEmail(Message message);

        void SendReservationConfirmationEmail(string userEmail, DateTime startDate, DateTime endDate);
    }
}
