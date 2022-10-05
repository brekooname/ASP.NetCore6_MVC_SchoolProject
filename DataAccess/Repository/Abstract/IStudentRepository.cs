
using Models.Concrete;

namespace DataAccess.Repository.Abstract
{
    public interface IStudentRepository : IRepository<Student>
    {
        void Update(Student student);
    }
}
