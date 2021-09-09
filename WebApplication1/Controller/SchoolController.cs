using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        [HttpPost("StudentAdd")]
        public IActionResult StudentAdd()
        {
            using var db = new SchoolDbContext();

            var list = new List<Student>()
            {
            new Student(){Name="emre"},
            new Student(){Name="ahmet"},
            new Student(){Name="mehmet"},
            new Student(){Name="hasan"},
            };
            //db.Students.AddRange(list);

            int[] ids = new int[3] {1,2,3};

            var p = db.Students.Find(2);

            p.SchoolStudents = ids.Select(cid => new SchoolStudent()
            {
            SchoolId= cid,
            StudentId=p.Id
            }).ToList();

            db.SaveChanges();

            return Ok();

        }
        [HttpPost("SchoolAdd")]
        public IActionResult SchoolAdd()
        {
            using var db = new SchoolDbContext();

            var list = new List<School>() 
            {
            new School(){Name="ibb"},
            new School(){Name="mehmetçik"},
            new School(){Name="beşyol"},
            new School(){Name="yuva"},
            };
            //db.Schools.AddRange(list);

            var test = db.Students.Include(c => c.SchoolStudents).ToList();

            //db.SaveChanges();
            return Ok(test);
        }
    }
}
