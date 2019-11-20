using System.Threading.Tasks;

namespace FluentApiGenericRepository.Interfaces
{
    public interface IUpdateable<in T>
        where T : class
    {
        void Update(T entity);
    }
}
