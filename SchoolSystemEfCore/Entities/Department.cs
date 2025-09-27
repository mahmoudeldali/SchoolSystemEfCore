using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemEfCore.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Budget { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
