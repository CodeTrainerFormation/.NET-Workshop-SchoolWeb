using Dal;
using DomainModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class StudentSyncController : Controller
    {
        private SchoolContext context;

        public StudentSyncController(SchoolContext context)
        {
            this.context = context;
        }

        // GET : Student/Index
        public IActionResult Index()
        {
            return View(this.context.Students.ToList());
        }

        // GET : Student/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();

            Student student = this.context.Students.Find(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // GET : Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST : Student/Create
        [HttpPost]
        public IActionResult Create([Bind("FirstName, LastName, Age, Average, IsClassDelegate")] Student student)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Students.Add(student);
                this.context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        // GET : Student/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            Student student = this.context.Students.Find(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST : Student/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, [Bind("PersonId, FirstName, LastName, Age, Average, IsClassDelegate")] Student student)
        {
            if (id != student.PersonId)
                return BadRequest();

            if (ModelState.IsValid)
            {
                //this.context.Entry(student).State = EntityState.Modified;
                this.context.Students.Update(student);
                this.context.SaveChanges();

                return RedirectToAction(nameof(Details), new { id = student.PersonId });
            }

            return View(student);
        }

        // GET : Student/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            Student student = this.context.Students.Find(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST : Student/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id, int personId)
        {
            if (id != personId)
                return BadRequest();

            Student student = this.context.Students.Find(personId);

            if (student == null)
                return NotFound();

            this.context.Students.Remove(student);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
