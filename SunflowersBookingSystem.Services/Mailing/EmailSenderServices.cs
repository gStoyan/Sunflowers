﻿namespace SunflowersBookingSystem.Services.Mailing
{
    using MailKit.Net.Smtp;
    using Microsoft.Extensions.Logging;
    using MimeKit;
    using SunflowersBookingSystem.Services.Helpers;
    using SunflowersBookingSystem.Services.Mailing.Interfaces;
    using SunflowersBookingSystem.Services.Models.Mailing;

    public class EmailSenderServices : IEmailSenderServices
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly ILogger _logger;
        private readonly IMailMessageBuilder _mailMessageBuilder;
        public EmailSenderServices(EmailConfiguration emailConfig, ILogger<EmailSenderServices> logger, IMailMessageBuilder mailMessageBuilder)
        {
            _emailConfig = emailConfig;
            _logger = logger;
            _mailMessageBuilder = mailMessageBuilder;
        }
        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        public void SendReservationConfirmationEmail(ConfirmationMessageBoddy body)
        {
            var confirmationMessage = _mailMessageBuilder.BuildConfirmationMessage(body);
            SendEmail(confirmationMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }
        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    client.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ServicesLogEvents.EmailService, $"Email service failed: {ex.Message}");
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
