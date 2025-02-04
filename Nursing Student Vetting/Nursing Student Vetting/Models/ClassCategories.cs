﻿using System.ComponentModel.DataAnnotations;

namespace Nursing_Student_Vetting.Models
{
    public class ClassCategories
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Please enter a category")]
        public string CategoryName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Please enter a prefix")]
        public string CategoryPrefix { get; set; } = String.Empty;
    }
}
