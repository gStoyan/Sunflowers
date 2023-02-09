namespace SunflowersBookingSystem.Services.Mailing.Interfaces
{
    public interface IMailMessageBuilder
    {
        void BuildConfirmationMessage(string email);
    }
}
