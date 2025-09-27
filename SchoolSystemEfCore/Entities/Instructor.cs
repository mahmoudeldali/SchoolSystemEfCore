using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemEfCore.Entities
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        // one-to-one
        public OfficeAssignment? OfficeAssignment { get; set; }
    }
}
