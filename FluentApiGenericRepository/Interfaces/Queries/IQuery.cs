using System;
using System.Linq.Expressions;

namespace FluentApiGenericRepository.Interfaces.Queries
{
    public interface IQuery<T> : IBaseQuery<T>
        where T : class
    {
        IJoinQuery<T, TProperty> Include<TProperty>(Expression<Func<T, TProperty>> includedProperty)
            where TProperty : class;

        IBaseQuery<TResult> Select<TResult>(Expression<Func<T, TResult>> selector);

        IOrderedQuery<T> OrderBy<TKey>(Expression<Func<T, TKey>> key);

        IOrderedQuery<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> key);
    }
}
