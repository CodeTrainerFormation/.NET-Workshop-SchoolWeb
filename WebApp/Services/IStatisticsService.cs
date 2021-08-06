using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IStatisticsService
    {
        public int GetStudentsCount();
        public int GetTeachersCount();
        public int GetClassroomsCount();
    }
}
