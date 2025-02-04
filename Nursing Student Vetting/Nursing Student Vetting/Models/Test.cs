using System.ComponentModel.DataAnnotations;

namespace Nursing_Student_Vetting.Models
{
    public class Test
    {
        public int TestID { get; set; }

        [Required(ErrorMessage = "Please enter a test name")]
        public string TestName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Please enter a grading scale")]
        public string GradingScale { get; set; } = String.Empty;
    }
}
