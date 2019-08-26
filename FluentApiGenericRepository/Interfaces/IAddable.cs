using System.Threading.Tasks;

namespace FluentApiGenericRepository.Interfaces
{
    public interface IAddable<in T>
        where T : class, IEntity
    {
        Task AddAsync(T entity);
    }
}
