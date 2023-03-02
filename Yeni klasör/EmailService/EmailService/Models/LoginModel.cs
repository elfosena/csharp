using System.ComponentModel.DataAnnotations;

namespace EmailService.Models
{
    public class LoginModel
    {
        [Required]
        public String Username { get; set; }
        [Required]
        public String Password { get; set; }
    }
}
