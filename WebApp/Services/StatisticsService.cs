using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly SchoolContext context;
        public StatisticsService(SchoolContext context)
        {
            this.context = context;
        }

        public int GetClassroomsCount()
        {
            return this.context.Classrooms.Count();
        }

        public int GetStudentsCount()
        {
            return this.context.Students.Count();
        }

        public int GetTeachersCount()
        {
            return this.context.Teachers.Count();
        }
    }
}
