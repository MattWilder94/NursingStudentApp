using System.ComponentModel.DataAnnotations;

namespace Nursing_Student_Vetting.Models
{
    public class StudentClass
    {
        // primary key
        public int ClassID { get; set; }

        public int StudentID { get; set; } // foreign key

        [Required(ErrorMessage = "Please enter a letter grade")]
        
        // Not sure if this is auto implemented of not??
        public string LetterGrade { get; set; } = String.Empty;

    }
}
