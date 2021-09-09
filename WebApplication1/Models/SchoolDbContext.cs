using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class SchoolDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;DataBase=SchoolDb;Trusted_Connection=true;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SchoolStudent>().HasKey(t => new { t.SchoolId, t.StudentId });

            modelBuilder.Entity<SchoolStudent>()
                .HasOne(ss => ss.School)
                .WithMany(s => s.SchoolStudents)
                .HasForeignKey(ss => ss.SchoolId);

            modelBuilder.Entity<SchoolStudent>()
               .HasOne(ss => ss.Student)
               .WithMany(s => s.SchoolStudents)
               .HasForeignKey(ss => ss.StudentId);



        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
