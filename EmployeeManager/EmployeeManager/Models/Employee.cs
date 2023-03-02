using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Model
{
    public class Employee
    {
        public int Id { get; set; } 
        public String FullName { get; set; }

        [EmailAddress]
        public String Email { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
