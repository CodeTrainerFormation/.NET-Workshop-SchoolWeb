using Dal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewComponents
{
    public class ListStudentViewComponent : ViewComponent
    {
        private readonly SchoolContext context;
        public ListStudentViewComponent(SchoolContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await this.context.Students
                                          .ToListAsync());
        }

        //public async Task<IViewComponentResult> InvokeAsync(int classroomId)
        //{
        //    return View(await this.context.Students
        //                                  .Include(s => s.Classroom)
        //                                  .Where(s => s.Classroom.ClassroomId == classroomId)
        //                                  .ToListAsync());
        //}
    }
}
