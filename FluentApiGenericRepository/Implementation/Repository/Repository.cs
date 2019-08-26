using System.Threading.Tasks;
using FluentApiGenericRepository.Interfaces;
using FluentApiGenericRepository.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace FluentApiGenericRepository.Implementation.Repository
{
    public class Repository<T> : ReadOnlyRepository<T>, IRepository<T>
        where T : class, IEntity
    {
        public Repository(DbContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task AddAsync(T entity)
        {
            await Entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            Entities.Update(entity);
        }

        public void Delete(T entity)
        {
            Entities.Remove(entity);
        }
    }
}
