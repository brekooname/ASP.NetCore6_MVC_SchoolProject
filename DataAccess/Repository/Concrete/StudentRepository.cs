
using DataAccess.Repository.Abstract;
using Models.Concrete;

namespace DataAccess.Repository.Concrete
{
    public class StudentRepository : Repository<Student>, IStudentRepository
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
    }
}
