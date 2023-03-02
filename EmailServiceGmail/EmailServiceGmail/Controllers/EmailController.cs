using EmailServiceGmail.Models;
using EmailServiceGmail.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailServiceGmail.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IMailService mailService;
        public EmailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send([FromForm] MailModel mail)
        {
            try
            {
                await mailService.SendEmailAsync(mail);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
