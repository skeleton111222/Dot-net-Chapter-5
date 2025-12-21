using EfCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=StudentDB.db");  // SQLite connection string
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Departments> Departments { get; set; }
    }
}
