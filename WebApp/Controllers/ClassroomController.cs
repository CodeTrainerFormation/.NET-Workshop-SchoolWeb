using Dal;
using DomainModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();

            Classroom classroom = this.context.Classrooms.Find(id);

            if (classroom == null)
                return NotFound();

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
        public IActionResult Create(string test)
        {
            return View();
        }
    }
}
