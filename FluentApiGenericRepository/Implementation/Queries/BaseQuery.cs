using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentApiGenericRepository.Interfaces.Queries;
using Microsoft.EntityFrameworkCore;

namespace FluentApiGenericRepository.Implementation.Queries
{
    public class BaseQuery<T> : IBaseQuery<T>
    {
        public IQueryable<T> Entities { get; protected set; }

        public BaseQuery(IQueryable<T> entities)
        {
            Entities = entities;
        }

        public IBaseQuery<T> Where(Expression<Func<T, bool>> predicate)
        {
            Entities = Entities.Where(predicate);

            return this;
        }

        public IBaseQuery<T> Take(int count)
        {
            Entities = Entities.Take(count);

            return this;
        }

        public IBaseQuery<T> Skip(int count)
        {
            Entities = Entities.Skip(count);

            return this;
        }

        public Task<int> CountAsync()
        {
            return Entities.CountAsync();
        }

        public async Task<IEnumerable<T>> ToListAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null ? await Entities.FirstOrDefaultAsync() : await Entities.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null ? await Entities.FirstAsync() : await Entities.FirstAsync(predicate);
        }
    }
}
