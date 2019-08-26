using System.Threading.Tasks;

namespace FluentApiGenericRepository.Interfaces
{
    public interface IUpdateable<in T>
        where T : class, IEntity
    {
        void Update(T entity);
    }
}
