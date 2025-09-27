using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemEfCore.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = null!;
        public int Credits { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
