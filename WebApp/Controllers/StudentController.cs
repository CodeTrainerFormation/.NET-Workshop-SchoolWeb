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
    public class StudentController : Controller
    {
        private SchoolContext context;

        public StudentController(SchoolContext context)
        {
            this.context = context;
        }

        // GET : Student/Index
        public async Task<IActionResult> Index()
        {
            return View(await this.context.Students.ToListAsync());
        }

        // GET : Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest();

            Student student = await this.context.Students.FindAsync(id);

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
        public async Task<IActionResult> Create([Bind("FirstName, LastName, Age, Average, IsClassDelegate")] Student student)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Students.Add(student);
                await this.context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        // GET : Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            Student student = await this.context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST : Student/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("PersonId, FirstName, LastName, Age, Average, IsClassDelegate")] Student student)
        {
            if (id != student.PersonId)
                return BadRequest();

            //if(...)
            //ModelState.AddModelError(string.Empty, "error message");

            if (ModelState.IsValid)
            {
                //this.context.Entry(student).State = EntityState.Modified;
                this.context.Students.Update(student);
                await this.context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new { id = student.PersonId });
            }

            return View(student);
        }

        // GET : Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            Student student = await this.context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST : Student/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, int personId)
        {
            if (id != personId)
                return BadRequest();

            Student student = await this.context.Students.FindAsync(personId);

            if (student == null)
                return NotFound();

            this.context.Students.Remove(student);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
