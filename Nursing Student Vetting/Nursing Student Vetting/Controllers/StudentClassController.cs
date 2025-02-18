using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nursing_Student_Vetting.Models;

namespace Nursing_Student_Vetting.Controllers
{
    public class StudentClassController : Controller
    {
        private readonly NursingStudentContext _context;

        public StudentClassController(NursingStudentContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Update(string studentId, int? classId, string? categoryPrefix)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return View(new StudentClass());
            }

            var studentClass = await _context.StudentClasses
                .Include(sc => sc.Student)
                .Include(sc => sc.Class)
                .FirstOrDefaultAsync(sc => sc.StudentID == studentId && sc.ClassID == classId && sc.CategoryPrefix == categoryPrefix);

            if (studentClass == null)
            {
                studentClass = new StudentClass { StudentID = studentId };
            }

            // Ensure these are never null by initializing them
            ViewBag.CategoryPrefixes = _context.Classes.Select(c => c.CategoryPrefix).Distinct().ToList() ?? new List<string>();
            ViewBag.Classes = await _context.Classes
                .Select(c => new { c.ClassID, DisplayText = c.CategoryPrefix + " - " + c.ClassID })
                .ToListAsync();

            return View(studentClass);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StudentClass studentClass)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(studentClass.StudentID) || string.IsNullOrEmpty(studentClass.CategoryPrefix) || studentClass.ClassID == 0)
                {
                    ModelState.AddModelError(string.Empty, "All fields are required.");

                    ViewBag.Classes = await _context.Classes.ToListAsync() ?? new List<Class>();
                    ViewBag.CategoryPrefixes = _context.Classes.Select(c => c.CategoryPrefix).Distinct().ToList() ?? new List<string>();

                    return View(studentClass);
                }

                // Check if the StudentClass entry already exists
                var existingStudentClass = await _context.StudentClasses
                    .FirstOrDefaultAsync(sc =>
                        sc.StudentID == studentClass.StudentID &&
                        sc.ClassID == studentClass.ClassID &&
                        sc.CategoryPrefix == studentClass.CategoryPrefix);

                if (existingStudentClass == null)
                {
                    // If not exists, add it to the database
                    _context.StudentClasses.Add(studentClass);
                }
                else
                {
                    // If exists, update it
                    existingStudentClass.LetterGrade = studentClass.LetterGrade;
                    _context.Update(existingStudentClass);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(StudentsController.Details),  //This right here got me on 2/18/2025. Always use nameof!
                    typeof(StudentsController).Name.Replace("Controller", ""), 
                    new { id =  studentClass.StudentID });
            }

            if (!ModelState.IsValid)
            {
                // Log the validation errors
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"Property: {state.Key}, Error: {error.ErrorMessage}");
                    }
                }
            }

            // If we got this far, something failed; redisplay form
            return View(studentClass);
        }

    }
}
