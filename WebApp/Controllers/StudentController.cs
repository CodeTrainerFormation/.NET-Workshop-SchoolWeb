using Dal;
using DomainModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext context;

        public StudentController(SchoolContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(this.context.Students.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();

            Student student = this.context.Students.Find(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Students.Add(student);
                this.context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            Student student = this.context.Students.Find(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.PersonId)
                return BadRequest();

            if (ModelState.IsValid)
            {
                this.context.Students.Update(student);
                this.context.SaveChanges();

                return RedirectToAction(nameof(Details), new { id = student.PersonId });
            }

            return View(student);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            Student student = this.context.Students.Find(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
                return BadRequest();

            Student student = this.context.Students.Find(id);

            if (student == null)
                return NotFound();

            this.context.Students.Remove(student);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
