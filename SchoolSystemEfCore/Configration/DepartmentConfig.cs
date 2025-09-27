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
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(d => d.DepartmentId);
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Budget).HasColumnType("decimal(18,2)");

            builder.HasData(
                new Department { DepartmentId = 1, Name = "Science", Budget = 50000m }
            );
        }
    }
}
