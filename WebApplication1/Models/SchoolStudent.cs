using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class SchoolStudent
    {
        public int StudentId { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public Student Student { get; set; }
    }
}
