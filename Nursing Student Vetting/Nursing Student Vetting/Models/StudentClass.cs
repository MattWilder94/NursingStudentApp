using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nursing_Student_Vetting.Models
{
    public class StudentClass
    {
        [Key, Column(Order = 0)]
        public int ClassID { get; set; }

        [Key, Column(Order = 1)]
        public int CategoryID { get; set; }

        [Key, Column(Order = 2)]
        public int StudentID { get; set; }

        public Class Class { get; set; }

        public Student Student { get; set; }

        [Required(ErrorMessage = "Please enter a letter grade")]
        
        // Not sure if this is auto implemented of not??
        public string LetterGrade { get; set; }

    }
}
