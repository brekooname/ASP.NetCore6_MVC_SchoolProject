
using DataAccess.Repository.Abstract;
using Models.Concrete;

namespace DataAccess.Repository.Concrete
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private readonly SchoolDbContext _db;

        public TeacherRepository(SchoolDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Teacher teacher)
        {
            _db.Update(teacher);
        }
    }
}
