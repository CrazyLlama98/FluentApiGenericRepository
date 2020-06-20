using System.Collections.Generic;
using System.Threading.Tasks;
using FluentApiGenericRepository.Implementation.Queries;
using FluentApiGenericRepository.Interfaces.Queries;
using FluentApiGenericRepository.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace FluentApiGenericRepository.Implementation.Repository
{
    public class GenericReadOnlyRepository<T> : IGenericReadOnlyRepository<T>
        where T : class
    {
        protected DbSet<T> Entities { get; set; }

        public GenericReadOnlyRepository(DbContext dbContext)
        {
            Entities = dbContext.Set<T>();
        }

        public virtual IQuery<T> Filter()
        {
            return new Query<T>(Entities);
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }
    }
}
