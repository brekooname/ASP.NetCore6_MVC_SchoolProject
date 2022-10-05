﻿namespace Models.Concrete
{
    public class ExamGrade
    {
        public int Id { get; set; }
        public string? Mid1 { get; set; }
        public string? Mid2 { get; set; }
        public string? Final { get; set; }
        public int? TeacherId { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
    }
}
