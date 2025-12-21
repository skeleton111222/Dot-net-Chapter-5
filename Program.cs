using System;
using System.Linq;
using EfCoreDemo.Data;
using EfCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        try
        {
            using (var context = new AppDbContext())
            {
                // Ensure the database and tables are created
                context.Database.EnsureCreated();

                // Create Department
                var dept = new Departments
                {
                    Name = "Computer Science"
                };

                context.Departments.Add(dept);
                context.SaveChanges();  // dept.Id generated here

                // Create Student
                var student = new Student
                {
                    Name = "Amit",
                    Age = 20,
                    DepartmentId = dept.Id  // Link student to department using foreign key
                };

                context.Students.Add(student);
                context.SaveChanges();  // Save student
            }

            Console.WriteLine("Department and Student inserted successfully!");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
        }

        // Viewing data
        using (var context = new AppDbContext())
        {
            var students = context.Students
                                  .Include(s => s.Department)
                                  .ToList();

            Console.WriteLine("\nStudent Information:\n");

            foreach (var student in students)
            {
                Console.WriteLine($"Student: {student.Name}, Age: {student.Age}, Department: {student.Department?.Name}");
            }
        }
    }
}
