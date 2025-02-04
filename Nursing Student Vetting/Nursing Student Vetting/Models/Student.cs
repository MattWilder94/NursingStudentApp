using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Nursing_Student_Vetting.Models
{
    public class Student
    {
        // Primary key
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        public String FirstName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Please enter a last name")]
        public String LastName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Please enter an email")]
        public String Email { get; set; } = String.Empty;

        [Required(ErrorMessage = "Please enter an address")]
        public String Address { get; set; } = String.Empty;

        [Required(ErrorMessage = "Please enter a date of birth")]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter a gender")]
        public String gender { get; set; } = String.Empty;

        [Required(ErrorMessage = "Please enter a starting date")]
        public DateOnly StartDate { get; set; }

        [Required(ErrorMessage = "Please enter a graduation state")]
        public DateOnly GraduationDate { get; set;}
    }
}
