using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Employee_Form_Using_HTML_and_CSS.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        public long Salary { get; set; }
        [Required(ErrorMessage = "DateOfBirth is required")]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public String Department { get; set; }

    }
}
