using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystemEfCore.Entities;
using System;

namespace SchoolSystem.Configurations
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(s => s.StudentId);

            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(50);
            builder.Property(s => s.EnrollmentDate).IsRequired();

            // Seed data
            builder.HasData(
                new Student { StudentId = 1, FirstName = "Ahmed", LastName = "Ali", EnrollmentDate = new DateTime(2023, 9, 1) },
                new Student { StudentId = 2, FirstName = "Sara", LastName = "Hassan", EnrollmentDate = new DateTime(2022, 9, 1) }
            );
        }
    }
}
