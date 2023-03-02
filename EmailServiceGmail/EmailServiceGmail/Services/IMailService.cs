using EmailServiceGmail.Models;

namespace EmailServiceGmail.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailModel mailModel);
    }
}
