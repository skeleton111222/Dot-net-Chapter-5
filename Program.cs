//using System;
//using System.Linq;
//using EfCoreDemo.Data;
//using EfCoreDemo.Models;
//using Microsoft.EntityFrameworkCore;

//class Program
//{
//    static void Main()
//    {
//        try
//        {
//            using (var context = new AppDbContext())
//            {
//                // Ensure the database and tables are created
//                //context.Database.EnsureCreated();

//                //// Create Department
//                //var dept = new Departments
//                //{
//                //    Name = "Computer Science"
//                //};

//                //context.Departments.Add(dept);
//                //context.SaveChanges();  // dept.Id generated here
//                // Fetch students initially and display
//                var students = context.Students.ToList();
//                Console.WriteLine("Initial Student Information:");
//                foreach (var s in students)
//                {
//                    Console.WriteLine($"Student ID: {s.Id}, Name: {s.Name}, Age: {s.Age}");
//                }

//                // Update a student and re-fetch students to display updated data
//                var student = context.Students.FirstOrDefault(s => s.Name == "Amit");
//                if (student != null)
//                {
//                    student.Age = 30;
//                    context.SaveChanges();
//                    Console.WriteLine("\nStudent record updated successfully!");
//                }
//                else
//                {
//                    Console.WriteLine("\nStudent 'Amit' not found!");
//                }
//                // Create Student
//                //var student = new Student
//                //{
//                //    Name = "Amit",
//                //    Age = 20,
//                //    DepartmentId = dept.Id  // Link student to department using foreign key
//                ////};
//                //context.Students.Add(student);

//                //context.SaveChanges(); // Save student

//                // Update student


//                //Console.WriteLine("Department and Student inserted successfully!");
//                Console.WriteLine("\nUpdated Student Information:");
//                foreach (var s in students)
//                {
//                    Console.WriteLine($"Name: {s.Name} - Age: {s.Age}");
//                }
//            }
//        }
//        catch (DbUpdateException ex)
//        {
//            Console.WriteLine($"Error: {ex.Message}");
//            Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
//        }

//        // Viewing data
//        using (var context = new AppDbContext())
//        {
//            var students = context.Students
//                                  .Include(s => s.Department)
//                                  .ToList();

//            Console.WriteLine("\nStudent Information:\n");

//            foreach (var student in students)
//            {
//                Console.WriteLine($"Student: {student.Name}, Age: {student.Age}, Department: {student.Department?.Name}");
//            }
//        }
//    }
//}

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
                // Fetch students initially and display
                var students = context.Students.ToList();
                Console.WriteLine("Initial Student Information:");
                foreach (var s in students)
                {
                    Console.WriteLine($"Student ID: {s.Id}, Name: {s.Name}, Age: {s.Age}");
                }

                // Update a student and re-fetch students to display updated data
                var student = context.Students.FirstOrDefault(s => s.Name == "Amit");
                if (student != null)
                {
                    student.Age = 30;
                    context.SaveChanges();
                    Console.WriteLine("\nStudent record updated successfully!");
                }
                else
                {
                    Console.WriteLine("\nStudent 'Amit' not found!");
                }

                // Re-fetch the students to show the updated information
                students = context.Students.ToList();
                Console.WriteLine("\nUpdated Student Information:");
                foreach (var s in students)
                {
                    Console.WriteLine($"Name: {s.Name} - Age: {s.Age}");
                }

                // Deleting a student
                var studentToDelete = context.Students.FirstOrDefault(s => s.Name == "Amit");

                // Delete student named "Amit" and age 30
                //var studentToDelete = context.Students.FirstOrDefault(s => s.Name == "Amit" && s.Age == 30);

                // Delete student with a specific Id (e.g., Id == 1)
                //var studentToDelete = context.Students.FirstOrDefault(s => s.Id == 1);
                if (studentToDelete != null)
                {
                    //context.Students.RemoveRange(studentToDelete);// DElete All Students with Name "Amit"

                    context.Students.Remove(studentToDelete)
                    context.SaveChanges();
                    Console.WriteLine("\nStudent 'Amit' deleted successfully!");
                }
                else
                {
                    Console.WriteLine("\nStudent 'Amit' not found for deletion!");
                }
            }
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
        }

        // Viewing data with related department information
        using (var context = new AppDbContext())
        {
            var students = context.Students
                                  .Include(s => s.Department)
                                  .ToList();

            Console.WriteLine("\nStudent Information with Department:\n");

            foreach (var student in students)
            {
                Console.WriteLine($"Student: {student.Name}, Age: {student.Age}, Department: {student.Department?.Name ?? "No Department"}");
            }
        }
    }
}

