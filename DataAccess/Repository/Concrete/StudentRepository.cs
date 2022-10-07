
using DataAccess.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using Models.Concrete;

namespace DataAccess.Repository.Concrete
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        private readonly SchoolDbContext _db;

        public StudentRepository(SchoolDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Student student)
        {
            _db.Update(student);
        }

        public IEnumerable<Course> GetStudentCourseList(int id)
        {
            var student = _db.Students.Include(s => s.Courses).FirstOrDefault(s => s.Id == id);

            return student.Courses;

        }
    }
}
