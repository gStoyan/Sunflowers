namespace SunflowersBookingSystem.Services.Mailing.Interfaces
{
    using SunflowersBookingSystem.Services.Models.Mailing;

    public interface IEmailSenderServices
    {
        void SendEmail(Message message);

        void SendReservationConfirmationEmail(ConfirmationMessageBoddy body);
    }
}
