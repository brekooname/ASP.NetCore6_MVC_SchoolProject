using Microsoft.EntityFrameworkCore;
using Models.Concrete;

namespace DataAccess
{
    public class SchoolDbContext : DbContext
    {
        
        public SchoolDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ExamGrade> ExamGrades { get; set; }
    }
}