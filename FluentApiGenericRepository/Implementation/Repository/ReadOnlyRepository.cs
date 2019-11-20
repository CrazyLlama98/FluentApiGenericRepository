using FluentApiGenericRepository.Interfaces;
using FluentApiGenericRepository.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace FluentApiGenericRepository.Implementation.Repository
{
    public class ReadOnlyRepository<T> : GenericReadOnlyRepository<T>, IReadOnlyRepository<T>
        where T : class, IEntity
    {
        public ReadOnlyRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
