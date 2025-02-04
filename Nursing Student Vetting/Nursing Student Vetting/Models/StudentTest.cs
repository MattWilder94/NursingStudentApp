using System.ComponentModel.DataAnnotations;

namespace Nursing_Student_Vetting.Models
{
    public class StudentTest
    {
        // primary key
        public int TestID { get; set; }

        // foreign key
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Please enter a test score")]
        public int TestScore { get; set; }
        
        public int AttemptNumber { get; set; }
    }
}
