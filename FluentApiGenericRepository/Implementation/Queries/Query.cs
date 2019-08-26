using System;
using System.Linq;
using System.Linq.Expressions;
using FluentApiGenericRepository.Interfaces.Queries;
using Microsoft.EntityFrameworkCore;

namespace FluentApiGenericRepository.Implementation.Queries
{
    public class Query<T> : BaseQuery<T>, IQuery<T>
        where T : class
    {
        public Query(IQueryable<T> entities) 
            : base(entities)
        {
        }

        public IJoinQuery<T, TProperty> Include<TProperty>(Expression<Func<T, TProperty>> includedProperty)
            where TProperty : class
        {
            return new JoinQuery<T, TProperty>(Entities.Include(includedProperty));
        }

        public IBaseQuery<TResult> Select<TResult>(Expression<Func<T, TResult>> selector)
        {
            return new BaseQuery<TResult>(Entities.Select(selector));
        }

        public IOrderedQuery<T> OrderBy<TKey>(Expression<Func<T, TKey>> key)
        {
            return new OrderedQuery<T>(Entities.OrderBy(key));
        }

        public IOrderedQuery<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> key)
        {
            return new OrderedQuery<T>(Entities.OrderByDescending(key));
        }
    }
}
