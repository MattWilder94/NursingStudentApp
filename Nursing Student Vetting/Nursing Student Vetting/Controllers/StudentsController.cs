﻿using Microsoft.AspNetCore.Mvc;
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
            List<Student> students = _context.Students.ToList();
            return View(students);
        }


        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return View(new Student()); // New student
            }

            Student? student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

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

                return View("List"); // "List" will probably be changed to addstudent.html
            }
        }

        [HttpPost] // basic delete action
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(p => p.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
        }
        
    }
}
