
using DataAccess.Repository.Abstract;
using Models.Concrete;

namespace DataAccess.Repository.Concrete
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        private readonly SchoolDbContext _db;

        public CourseRepository(SchoolDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Course course)
        {
            _db.Update(course);
        }
    }
}
