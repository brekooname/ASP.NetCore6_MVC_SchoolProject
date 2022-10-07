 
namespace Models.Concrete.ViewModels.ExamGradeVMs
{
    public class ExamGradeFullViewModel
    {
        public IEnumerable<ExamGrade> ExamGradeList { get; set; }
        public IEnumerable<Student> StudentList { get; set; }
        public IEnumerable<Teacher> TeacherList { get; set; }
        public IEnumerable<Course> CourseList { get; set; }
    }
}
