using Dal;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                context.Initialize();

                foreach (var person in context.People.AsNoTracking())
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName}, {person.Age}yo");
                }

                //context.Classrooms.ToList();
                //context.Classrooms.Find(2);
                //context.Classrooms.Include(c => c.Students)
                //                  .Single(c => c.ClassroomId == 1);

                //context.Classrooms.Add();
                //context.Classrooms.Update();
                //context.Classrooms.Remove();

            } // context.Dispose();

            Console.WriteLine("OK !");
        }
    }
}
