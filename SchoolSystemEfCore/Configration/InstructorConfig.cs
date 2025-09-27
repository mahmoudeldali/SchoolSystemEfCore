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
    public class InstructorConfig : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors");
            builder.HasKey(i => i.InstructorId);
            builder.Property(i => i.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(i => i.LastName).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Instructor { InstructorId = 1, FirstName = "Mohamed", LastName = "Youssef" }
            );
        }
    }
}
