using System.Threading.Tasks;
using FluentApiGenericRepository.Extensions;
using Xunit;

namespace FluentApiGenericRepository.Test.QueryTests
{
    public class JoinQueryShould
    {
        private readonly TestsDataProvider _dataProvider;

        public JoinQueryShould()
        {
            _dataProvider = new TestsDataProvider();
        }

        [Fact]
        public async Task ReturnNotNullSubSubEntityWhenCallingThenIncludeFromEnumerableJoinQuery()
        {
            // arrange
            var entities = new[]
            {
                new TestEntity
                {
                    Name = "test",
                    SubEntities = new[] {new SubEntity {SubSubEntity = new SubSubEntity()}, new SubEntity {SubSubEntity = new SubSubEntity()}}
                }
            };
            _dataProvider.AddEntities(entities);

            // act
            var result = await _dataProvider.ReadOnlyRepository
                .Filter()
                .Include(test => test.SubEntities)
                .ThenInclude(subEntity => subEntity.SubSubEntity)
                .FirstOrDefaultAsync();

            // assert
            Assert.All(result.SubEntities, subEntity => Assert.NotNull(subEntity.SubSubEntity));
        }

        [Fact]
        public async Task ReturnNotNullSubSubEntityWhenCallingThenIncludeFromObjectJoinQuery()
        {
            // arrange
            var entities = new[]
            {
                new TestEntity
                {
                    Name = "test",
                    TestDetails = new TestDetails { SubSubEntity = new SubSubEntity() }
                }
            };
            _dataProvider.AddEntities(entities);

            // act
            var result = await _dataProvider.ReadOnlyRepository
                .Filter()
                .Include(test => test.TestDetails)
                .ThenInclude(td => td.SubSubEntity)
                .FirstOrDefaultAsync();

            // assert
            Assert.NotNull(result.TestDetails.SubSubEntity);
        }
    }
}
