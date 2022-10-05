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
        public Course Course { get; set; }
        public ICollection<ExamGrade> ExamGrades { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
