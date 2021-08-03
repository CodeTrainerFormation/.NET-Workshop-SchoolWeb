using Dal;
using DomainModel;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                context.Initialize();

                foreach (var person in context.People)
                {
                    Console.WriteLine(person.FirstName);
                }

            } // context.Dispose();

            Console.WriteLine("OK !");
        }
    }
}
