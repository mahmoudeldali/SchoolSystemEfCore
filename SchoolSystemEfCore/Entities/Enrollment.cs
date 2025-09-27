using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemEfCore.Entities
{
    public class Enrollment
    {
        // composite key: StudentId + CourseId
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal? Grade { get; set; }

        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
