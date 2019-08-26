using System.Threading.Tasks;
using Xunit;

namespace FluentApiGenericRepository.Test.RepositoryTests
{
    public class RepositoryShould
    {
        private readonly TestsDataProvider _dataProvider;

        public RepositoryShould()
        {
            _dataProvider = new TestsDataProvider();
        }

        [Fact]
        public async Task AddANewEntityWhenCallingAddAsync()
        {
            // arrange
            var entity = new TestEntity
            {
                Name = "test1",
                Number = 1
            };

            // act
            await _dataProvider.Repository.AddAsync(entity);

            // assert
            Assert.Equal(entity, await _dataProvider.DbContext.TestEntities.FindAsync(entity.Id));
        }

        [Fact]
        public async Task UpdateExistingEntityWhenCallingUpdate()
        {
            // arrange
            var entityToUpdate = new TestEntity { Name = "test1", Number = 1 };
            _dataProvider.AddEntities(entityToUpdate);
            entityToUpdate.Name = "testupdated1";

            // act
            _dataProvider.Repository.Update(entityToUpdate);
            await _dataProvider.DbContext.SaveChangesAsync();

            // assert
            Assert.Equal(entityToUpdate, await _dataProvider.DbContext.TestEntities.FindAsync(entityToUpdate.Id));
        }

        [Fact]
        public async Task DeleteExistingEntityWhenCallingDelete()
        {
            // arrange
            var entityToDelete = new TestEntity { Name = "test1", Number = 1 };
            _dataProvider.AddEntities(entityToDelete);
            var entityId = entityToDelete.Id;

            // act
            _dataProvider.Repository.Delete(entityToDelete);
            await _dataProvider.DbContext.SaveChangesAsync();

            // assert
            Assert.Null(await _dataProvider.DbContext.TestEntities.FindAsync(entityId));
        }
    }
}
