using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Model
{
    public class EmployeeModel
    {
        [Required]
        public String FullName { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
    }
}
