using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Concrete
{
    public class Teacher
    {
        public Teacher()
        {
            Students = new HashSet<Student>();
            ExamGrades = new HashSet<ExamGrade>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CourseId { get; set; }

        [ValidateNever]
        public Course Course { get; set; }
        public ICollection<ExamGrade> ExamGrades { get; set; }
        public ICollection<Student> Students { get; set; }

        [NotMapped]
        public string FullName { get => $"{Name} {LastName}"; }
    }
}

