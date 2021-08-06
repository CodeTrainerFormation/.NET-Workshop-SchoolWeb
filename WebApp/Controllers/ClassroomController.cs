using Dal;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Filters;

namespace WebApp.Controllers
{
    //[Route("Class")]
    public class ClassroomController : Controller
    {
        private SchoolContext context;

        public ClassroomController(SchoolContext context)
        {
            this.context = context;
        }

        // GET: Class
        // GET: Class/List
        //[Route("")]
        //[Route("List")]
        public IActionResult Index()
        {
            var classrooms = this.context.Classrooms.ToList();

            return View(classrooms);
        }

        // GET: Classroom/Details/5
        [Log]
        //[Route("Details/{id?}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();

            //Classroom classroom = this.context.Classrooms.Find(id);
            Classroom classroom = this.context.Classrooms
                                              .Include(c => c.Students)
                                              .SingleOrDefault(c => c.ClassroomId == id);

            if (classroom == null)
                return NotFound();

            //ViewData["Title"] = "Hello world";
            //ViewBag.Title = "Hello world";

            return View(classroom);
        }

        // GET: Classroom/Create
        [HttpGet]
        //[Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classroom/Create
        [HttpPost]
        public IActionResult Create(Classroom classroom)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Classrooms.Add(classroom);
                this.context.SaveChanges();
                return RedirectToAction(nameof(Details), new { id = classroom.ClassroomId });
            }

            return View(classroom);
        }

        // GET : Classroom/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            Classroom classroom = await this.context.Classrooms.FindAsync(id);

            if (classroom == null)
                return NotFound();

            return View(classroom);
        }

        // POST : Classroom/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ClassroomId,Name,Floor,Corridor")] Classroom classroom)
        {
            if (id != classroom.ClassroomId)
                return BadRequest();

            if (ModelState.IsValid)
            {
                this.context.Classrooms.Update(classroom);
                await this.context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new { id = classroom.ClassroomId });
            }

            return View(classroom);
        }

        // GET: Classroom/Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            Classroom classroom = this.context.Classrooms.Find(id);

            if (classroom == null)
                return NotFound();

            return View(classroom);
        }

        // POST: Classroom/Delete
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
                return BadRequest();

            Classroom classroom = this.context.Classrooms.Find(id);

            if (classroom == null)
                return NotFound();

            this.context.Classrooms.Remove(classroom);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
