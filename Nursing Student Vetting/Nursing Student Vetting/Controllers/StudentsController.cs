using Microsoft.AspNetCore.Mvc;

namespace Nursing_Student_Vetting.Controllers
{
    public class StudentsController : Controller
    {
        private readonly NursingStudentContext _context;

        public StudentsController(NursingStudentContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            var students = _context.Students.ToList();
            return View(students);
        }
    }
}
