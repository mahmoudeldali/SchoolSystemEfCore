using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystemEfCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemEfCore.Configration
{
    public class OfficeAssignmentConfig : IEntityTypeConfiguration<OfficeAssignment>
    {
        public void Configure(EntityTypeBuilder<OfficeAssignment> builder)
        {
            builder.ToTable("OfficeAssignments");
            builder.HasKey(o => o.InstructorId);
            builder.Property(o => o.Location).IsRequired().HasMaxLength(100);

            builder.HasOne(o => o.Instructor)
                   .WithOne(i => i.OfficeAssignment)
                   .HasForeignKey<OfficeAssignment>(o => o.InstructorId);

            builder.HasData(
                new OfficeAssignment { InstructorId = 1, Location = "Room 101" }
            );
        }
    }
}
