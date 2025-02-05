using System.ComponentModel.DataAnnotations;

namespace Nursing_Student_Vetting.Models
{
    public class Class
    {
        [Required(ErrorMessage = "Please enter a Class Id")]
        public int ClassID { get; set; } // primary key

        public int CategoryID { get; set; } // foreign key

        [Required(ErrorMessage = "Please enter a class name")]
        public string ClassName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Please enter number of credit hours")]
        public int CreditHours { get; set; }


        // not sure if this should be a string or a bool?

        public bool IsRequired { get; set; }
    }
}
