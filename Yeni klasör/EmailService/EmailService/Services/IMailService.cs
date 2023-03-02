using EmailService.Models;

namespace EmailService.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailModel mailModel);
    }
}
