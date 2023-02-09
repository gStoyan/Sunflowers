namespace SunflowersBookingSystem.Services.Mailing
{
    using NPOI.XWPF.Extractor;
    using NPOI.XWPF.UserModel;
    using SunflowersBookingSystem.Services.Mailing.Interfaces;
    using SunflowersBookingSystem.Services.Models.Mailing;

    internal class MailMessageBuilder : IMailMessageBuilder
    {

        public void BuildConfirmationMessage(string userEmail)
        {

            XWPFDocument document = null;
            using (FileStream file = new FileStream("../SunflowersBookingSystem.Services/Resources/ReservationConfirmation.docx", FileMode.Open, FileAccess.Read))
            {
                document = new XWPFDocument(file);
                XWPFWordExtractor ex = new XWPFWordExtractor(document);
                var emailDocumentText = ex.Text;

                var emailMessage = new Message(new string[] { $"{userEmail}" }, "Reservation Confirmation", emailDocumentText);
            }
        }
    }
}
