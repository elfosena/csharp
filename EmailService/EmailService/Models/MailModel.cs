using System.ComponentModel.DataAnnotations;

namespace EmailService.Models
{
    public class MailModel
    {
        [EmailAddress]
        public string Reciever { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public List<IFormFile>? Attachments { get; set; }
    }
}
