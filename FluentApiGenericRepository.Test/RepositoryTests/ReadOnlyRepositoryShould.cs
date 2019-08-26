using System.Threading.Tasks;
using Xunit;

namespace FluentApiGenericRepository.Test.RepositoryTests
{
    public class ReadOnlyRepositoryShould
    {
        private readonly TestsDataProvider _dataProvider;

        public ReadOnlyRepositoryShould()
        {
            _dataProvider = new TestsDataProvider();
        }

        [Fact]
        public async Task ReturnAllEntitiesWhenCallingGetAll()
        {
            // arrange
            var entities = new [] { new TestEntity { Name = "test 1" }, new TestEntity { Name = "test2" } };
            _dataProvider.AddEntities(entities);

            // act
            var result = await _dataProvider.ReadOnlyRepository.GetAllAsync();

            // assert
            Assert.Equal(entities, result);
        }

        [Fact]
        public async Task ReturnEntityById()
        {
            // arrange
            var entity = new TestEntity();
            _dataProvider.AddEntities(entity);

            // act
            var result = await _dataProvider.ReadOnlyRepository.GetByIdAsync(entity.Id);

            // arrange
            Assert.Equal(entity.Id, result.Id);
        }
    }
}
