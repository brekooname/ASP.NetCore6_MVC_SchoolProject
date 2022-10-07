using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Concrete
{
    public class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
            Teachers = new HashSet<Teacher>();
            ExamGrades = new HashSet<ExamGrade>();
        }

        public int Id { get; set; } 
        public string StudentNo { get; set; } 
        public string Name { get; set; } 
        public string LastName { get; set; } 
        public string UserName { get; set; } 
        public string Password { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<ExamGrade> ExamGrades { get; set; }

        [NotMapped]
        public string FullName { get => $"{Name} {LastName}"; }
    }
}