
using Core.Entities;

namespace Core.DataAccess
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
    }
}
