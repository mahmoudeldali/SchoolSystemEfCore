namespace SchoolSystemEfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolSystemEfCore.Data;      // تأكد namespace صح
using SchoolSystemEfCore.Entities;  // لو هتستخدم الأصناف هنا
using System;
using System.Linq;


internal class Program
{


    static void Main()
    {
        // --------------------------------------------------------------------
        // 1) Connection string مَعرّف مباشرة هنا (بدّلها لو عندك SQL Server اسم تاني)
        // --------------------------------------------------------------------
        var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=SchoolDb;Trusted_Connection=True;TrustServerCertificate=True";

        // --------------------------------------------------------------------
        // 2) بناء DbContextOptions
        // --------------------------------------------------------------------
        var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
        optionsBuilder.UseSqlServer(connectionString);

        // --------------------------------------------------------------------
        // 3) استخدم الـ DbContext عادي داخل using
        // --------------------------------------------------------------------
        using (var context = new SchoolContext(optionsBuilder.Options))
        {
            Console.WriteLine("Starting EF Core Console demo (no appsettings.json)...");

            // إذا حابب تطبق أي مَيجرِيشِن معمول بالفعل تلقائياً عند التشغيل:
            // (مفيد لو عملت migrations مسبقًا عبر Add-Migration)
            try
            {
                context.Database.Migrate();
                Console.WriteLine("Database migrated/ensured.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Warning: Failed to run migrations at runtime. OK if you prefer to use 'Add-Migration' + 'Update-Database'.");
                Console.WriteLine(ex.Message);
            }

            // ---------- مثال استعلام (Query Syntax: join بين Students, Enrollments, Courses) ----------
            var studentCourses = from s in context.Students
                                 join e in context.Enrollments on s.StudentId equals e.StudentId
                                 join c in context.Courses on e.CourseId equals c.CourseId
                                 select new { Student = s.FirstName + " " + s.LastName, c.Title, e.Grade };

            Console.WriteLine("\nStudent enrollments (join):");
            foreach (var sc in studentCourses)
                Console.WriteLine($"{sc.Student} - {sc.Title}: {sc.Grade}");

            // ---------- مثال Method Syntax مع Include (navigation) ----------
            var departments = context.Departments
                                     .Include(d => d.Courses)
                                     .ToList();

            Console.WriteLine("\nDepartments and their courses:");
            foreach (var d in departments)
                Console.WriteLine($"{d.Name}: {string.Join(", ", d.Courses.Select(c => c.Title))}");

            // ---------- مثال Navigation من Student => Enrollments => Course ----------
            var firstStudent = context.Students
                                      .Include(s => s.Enrollments)
                                      .ThenInclude(e => e.Course)
                                      .FirstOrDefault();

            if (firstStudent != null)
            {
                Console.WriteLine($"\nCourses for {firstStudent.FirstName} {firstStudent.LastName}:");
                foreach (var en in firstStudent.Enrollments)
                    Console.WriteLine($"- {en.Course.Title} (Grade: {en.Grade})");
            }

            Console.WriteLine("\nDone.");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}