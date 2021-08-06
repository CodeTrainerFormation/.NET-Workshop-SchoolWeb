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
    public class ClassroomController : Controller
    {
        private SchoolContext context;

        public ClassroomController(SchoolContext context)
        {
            this.context = context;
        }

        // GET: Classroom/Index
        public IActionResult Index()
        {
            var classrooms = this.context.Classrooms.ToList();

            return View(classrooms);
        }

        // GET: Classroom/Details/5
        [Log]
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
