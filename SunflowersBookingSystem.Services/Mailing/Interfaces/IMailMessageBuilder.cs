namespace SunflowersBookingSystem.Services.Mailing.Interfaces
{
    using SunflowersBookingSystem.Services.Models.Mailing;

    public interface IMailMessageBuilder
    {
        Message BuildConfirmationMessage(ConfirmationMessageBoddy body);
    }
}
