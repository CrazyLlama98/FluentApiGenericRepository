using System;
using System.Linq.Expressions;

namespace FluentApiGenericRepository.Interfaces.Queries
{
    public interface IOrderedQuery<T> : IQuery<T>
        where T : class
    {
        IOrderedQuery<T> ThenBy<TKey>(Expression<Func<T, TKey>> key);

        IOrderedQuery<T> ThenByDescending<TKey>(Expression<Func<T, TKey>> key);
    }
}
