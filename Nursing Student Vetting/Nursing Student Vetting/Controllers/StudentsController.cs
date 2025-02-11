using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nursing_Student_Vetting.Models;

namespace Nursing_Student_Vetting.Controllers
{
    public class StudentsController : Controller
    {
        private readonly NursingStudentContext _context;
        private List<Student> students;

        public StudentsController(NursingStudentContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(List));
        }

        public IActionResult List()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Add()
        {
            Student student = new Student();

            ViewBag.Student = student;

            return View(student);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Student student = _context.Students  // returning student name and ID
                .Include(s => s.FirstName)
                .Include(s => s.LastName)
                .FirstOrDefault(s => s.StudentID == id) ?? new Student();

            ViewBag.Student = student;

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Student student) 
        {

            if (ModelState.IsValid)
            {
                bool exists = await _context.Students.AnyAsync(p => p.StudentID == student.StudentID);

                if (!exists)        // if student is new
                {
                    _context.Students.Add(student);
                }
                else
                {
                    _context.Students.Update(student);  // update existing student
                }
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Student = students;

                return View("List", student); // "List" will probably be changed to addstudent.html
            }
        }
    }
}
