using System.Threading.Tasks;

namespace FluentApiGenericRepository.Interfaces
{
    public interface IDeletable<in T>
        where T : class, IEntity
    {
        void Delete(T entity);
    }
}
