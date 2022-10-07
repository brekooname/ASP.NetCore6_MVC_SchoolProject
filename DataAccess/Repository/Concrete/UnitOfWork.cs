
using DataAccess.Repository.Abstract;

namespace DataAccess.Repository.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolDbContext _db;

        public UnitOfWork(SchoolDbContext db)
        {
            _db = db;
            StudentRepository = new StudentRepository(_db);
            TeacherRepository = new TeacherRepository(_db);
            CourseRepository = new CourseRepository(_db);
        }

        public IStudentRepository StudentRepository{ get; private set; }
        public ITeacherRepository TeacherRepository{ get; private set; }
        public ICourseRepository CourseRepository{ get; private set; }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
