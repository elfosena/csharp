namespace EmailServiceGmail.Models
{
    public class MailModel
    {
        public string Reciever { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
