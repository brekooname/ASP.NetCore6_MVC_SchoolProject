namespace Models.Concrete.ViewModels.TeacherVMs
{
    public class TeacherListViewModel
    {
        public IEnumerable<Teacher> TeacherList { get; set; }
        public IEnumerable<Course> CourseList { get; set; }
    }
}
