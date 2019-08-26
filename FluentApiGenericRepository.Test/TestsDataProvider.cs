using System;
using System.Linq;
using FluentApiGenericRepository.Implementation;
using FluentApiGenericRepository.Implementation.Repository;
using FluentApiGenericRepository.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace FluentApiGenericRepository.Test
{
    public class TestsDataProvider
    {
        public TestContext DbContext { get; set; }
        public IReadOnlyRepository<TestEntity> ReadOnlyRepository { get; set; }
        public IRepository<TestEntity> Repository { get; set; }

        public TestsDataProvider()
        {
            DbContext = new TestContext(CreateDbContextOptions());
            ReadOnlyRepository = new ReadOnlyRepository<TestEntity>(DbContext);
            Repository = new Repository<TestEntity>(DbContext);
        }

        private DbContextOptions<TestContext> CreateDbContextOptions()
        {
            var builder = new DbContextOptionsBuilder<TestContext>();

            return builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        }

        public void AddEntities(params TestEntity[] entities)
        {
            DbContext.AddRange(entities.AsEnumerable());
            DbContext.SaveChanges();
        }
    }
}
