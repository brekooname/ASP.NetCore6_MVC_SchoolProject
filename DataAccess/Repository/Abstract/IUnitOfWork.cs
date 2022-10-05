namespace DataAccess.Repository.Abstract
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }
        public Task SaveAsync();
    }
}
