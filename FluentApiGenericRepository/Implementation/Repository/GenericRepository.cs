using System.Threading.Tasks;
using FluentApiGenericRepository.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace FluentApiGenericRepository.Implementation.Repository
{
    public class GenericRepository<T> : GenericReadOnlyRepository<T>, IGenericRepository<T>
        where T : class
    {
        public GenericRepository(DbContext dbContext) 
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
