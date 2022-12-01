using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ShopApp.WebUI.EmailService
{
    public class EmailSender : IEmailSender
    {
        private const string SendGridKey = "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";
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(SendGridKey, subject, htmlMessage, email);
        }

        private Task Execute(string sendGridKey, string subject, string message, string email)
        {
            var client = new SendGridClient(sendGridKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("info@shopapp.com", "Shop App"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }
    }
}
