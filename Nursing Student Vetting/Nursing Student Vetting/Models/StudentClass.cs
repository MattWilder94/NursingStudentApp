using System.ComponentModel.DataAnnotations;

namespace Nursing_Student_Vetting.Models
{
    public class StudentClass
    {
        [Key]
        public int ClassID { get; set; }
        public Class Class { get; set; }
        [Required]
        public int StudentID { get; set; } // foreign key
        public Student Student { get; set; }

        [Required(ErrorMessage = "Please enter a letter grade")]
        
        // Not sure if this is auto implemented of not??
        public char LetterGrade { get; set; }

    }
}
