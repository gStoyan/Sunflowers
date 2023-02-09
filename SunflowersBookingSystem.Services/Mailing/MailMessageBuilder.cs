namespace SunflowersBookingSystem.Services.Mailing
{
    using System.Text;
    using NPOI.XWPF.Extractor;
    using NPOI.XWPF.UserModel;
    using SunflowersBookingSystem.Services.Mailing.Interfaces;
    using SunflowersBookingSystem.Services.Models.Mailing;

    public class MailMessageBuilder : IMailMessageBuilder
    {

        public Message BuildConfirmationMessage(ConfirmationMessageBoddy body)
        {

            XWPFDocument document = null;
            using (FileStream file = new FileStream("../SunflowersBookingSystem.Services/Resources/ReservationConfirmation.docx", FileMode.Open, FileAccess.Read))
            {
                document = new XWPFDocument(file);
                XWPFWordExtractor ex = new XWPFWordExtractor(document);
                var emailDocumentText = ex.Text;
                var reworkedText = ReplacePLaceholdersConfirmationMessage(emailDocumentText, body);


                var emailMessage = new Message(new string[] { $"{body.Email}" }, "Reservation Confirmation", reworkedText);

                return emailMessage;
            }
        }

        private string ReplacePLaceholdersConfirmationMessage(string text, ConfirmationMessageBoddy body)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(text);

            sb.Replace("{{firstName}}", body.FirstName);
            sb.Replace("{{lastName}}", body.LastName);
            sb.Replace("{{startDate}}", body.StartDate.ToShortDateString());
            sb.Replace("{{endDate}}", body.EndDate.ToShortDateString());

            return sb.ToString();
        }
    }
}
