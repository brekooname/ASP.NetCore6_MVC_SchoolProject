namespace Models.Concrete
{
    public class Course
    {
        public Course()
        {
            Teachers = new HashSet<Teacher>();
            Students = new HashSet<Student>();
            ExamGrades = new HashSet<ExamGrade>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<ExamGrade> ExamGrades { get; set; }
    }
}
