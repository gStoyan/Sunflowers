namespace SunflowersBookingSystem.Services.Models.Mailing
{
    public class ConfirmationMessageBoddy
    {
        public ConfirmationMessageBoddy(string email, string firstName, string lastName, DateTime startDate, DateTime endDate)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            StartDate = startDate;
            EndDate = endDate;
        }

        public string Email { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }
    }
}
