using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemEfCore.Entities
{
    public class OfficeAssignment
    {
        public int InstructorId { get; set; } // PK and FK to Instructor
        public string Location { get; set; } = null!;

        public Instructor Instructor { get; set; } = null!;
    }
}
