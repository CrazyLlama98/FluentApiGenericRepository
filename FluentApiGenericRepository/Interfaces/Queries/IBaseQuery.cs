using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FluentApiGenericRepository.Interfaces.Queries
{
    public interface IBaseQuery<T>
    {
        IQueryable<T> Entities { get; }

        IBaseQuery<T> Where(Expression<Func<T, bool>> predicate);

        IBaseQuery<T> Take(int count);

        IBaseQuery<T> Skip(int count);

        Task<int> CountAsync();

        Task<IEnumerable<T>> ToListAsync();

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null);

        Task<T> FirstAsync(Expression<Func<T, bool>> predicate = null);
    }
}
