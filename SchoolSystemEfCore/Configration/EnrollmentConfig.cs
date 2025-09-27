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
    public class EnrollmentConfig : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollments");
            builder.HasKey(e => new { e.StudentId, e.CourseId });

            builder.Property(e => e.Grade).HasColumnType("decimal(5,2)");

            builder.HasOne(e => e.Student)
                   .WithMany(s => s.Enrollments)
                   .HasForeignKey(e => e.StudentId);

            builder.HasOne(e => e.Course)
                   .WithMany(c => c.Enrollments)
                   .HasForeignKey(e => e.CourseId);

            builder.HasData(
                new Enrollment { StudentId = 1, CourseId = 1, Grade = 90m },
                new Enrollment { StudentId = 1, CourseId = 2, Grade = 85m },
                new Enrollment { StudentId = 2, CourseId = 1, Grade = 78m }
            );
        }
    }
}
