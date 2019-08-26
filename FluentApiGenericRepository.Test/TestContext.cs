using Microsoft.EntityFrameworkCore;

namespace FluentApiGenericRepository.Test
{
    public class TestContext : DbContext
    {
        public DbSet<TestEntity> TestEntities { get; set; }
        public DbSet<SubEntity> SubEntities { get; set; }
        public DbSet<SubSubEntity> SubSubEntities { get; set; }
        public DbSet<TestDetails> TestDetails { get; set; }

        public TestContext(DbContextOptions<TestContext> contextOptions)
            : base(contextOptions)
        {
        }
    }
}
