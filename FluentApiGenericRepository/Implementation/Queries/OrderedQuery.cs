using System;
using System.Linq;
using System.Linq.Expressions;
using FluentApiGenericRepository.Interfaces.Queries;

namespace FluentApiGenericRepository.Implementation.Queries
{
    public class OrderedQuery<T> : Query<T>, IOrderedQuery<T>
        where T : class
    {
        public OrderedQuery(IOrderedQueryable<T> entities) 
            : base(entities)
        {
        }

        public IOrderedQuery<T> ThenBy<TKey>(Expression<Func<T, TKey>> key)
        {
            Entities = ((IOrderedQueryable<T>) Entities).ThenBy(key);

            return this;
        }

        public IOrderedQuery<T> ThenByDescending<TKey>(Expression<Func<T, TKey>> key)
        {
            Entities = ((IOrderedQueryable<T>) Entities).ThenByDescending(key);

            return this;
        }
    }
}
