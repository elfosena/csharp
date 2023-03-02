using System.ComponentModel.DataAnnotations;

namespace EmailService.Models
{
    public class User
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
    }
}
