 
namespace Models.Concrete.ViewModels.ExamGradeVMs
{
    public class ExamGradeByStudentIdViewModel
    {
        public IEnumerable<Course> CourseList { get; set; }
        public IEnumerable<ExamGrade> ExamGradeList{ get; set; }
        public Student Student { get; set; }

    }
}
