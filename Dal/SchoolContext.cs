using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dal
{
    public class SchoolContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Administrative> Administratives { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=SchoolDatabase;Integrated Security=true");
            //optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=SchoolDatabase;Integrated Security=true");

            base.OnConfiguring(optionsBuilder);
        }

        // FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Classroom>()
            //            .HasOne(c => c.Teacher)
            //            .WithOne(t => t.Classroom);

            base.OnModelCreating(modelBuilder);
        }
    }
}
