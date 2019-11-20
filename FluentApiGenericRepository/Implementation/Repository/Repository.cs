using FluentApiGenericRepository.Interfaces;
using FluentApiGenericRepository.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace FluentApiGenericRepository.Implementation.Repository
{
    public class Repository<T> : GenericRepository<T>, IRepository<T>
        where T : class, IEntity
    {
        public Repository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
