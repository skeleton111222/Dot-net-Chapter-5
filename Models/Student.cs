namespace EfCoreDemo.Models
{
    public class Student
    {
        public int Id { get; set; }  // Primary Key
        public string Name { get; set; } =null!;
        public int Age { get; set; }

        // Foreign Key for Departments
        public int DepartmentId { get; set; }
        public Departments Department { get; set; }  // Navigation Property
    }
}
