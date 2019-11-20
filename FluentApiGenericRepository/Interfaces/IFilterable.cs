using System.Collections.Generic;
using System.Threading.Tasks;
using FluentApiGenericRepository.Interfaces.Queries;

namespace FluentApiGenericRepository.Interfaces
{
    public interface IFilterable<T>
        where T : class
    {
        IQuery<T> Filter();

        Task<T> GetByIdAsync(object id);

        Task<IEnumerable<T>> GetAllAsync();
    }
}
