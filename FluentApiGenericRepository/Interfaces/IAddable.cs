using System.Threading.Tasks;

namespace FluentApiGenericRepository.Interfaces
{
    public interface IAddable<in T>
        where T : class
    {
        Task AddAsync(T entity);
    }
}
