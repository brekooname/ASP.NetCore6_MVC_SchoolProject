
using DataAccess.Repository.Abstract;
using Models.Concrete;

namespace DataAccess.Repository.Concrete
{
    public class ExamGradeRepository : RepositoryBase<ExamGrade>, IExamGradeRepository
    {
        private readonly SchoolDbContext _db;

        public ExamGradeRepository(SchoolDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ExamGrade examGrade)
        {
            _db.Update(examGrade);
        }
    }
}
