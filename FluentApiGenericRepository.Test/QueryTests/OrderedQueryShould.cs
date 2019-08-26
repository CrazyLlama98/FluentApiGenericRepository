using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FluentApiGenericRepository.Test.QueryTests
{
    public class OrderedQueryShould
    {
        private readonly TestsDataProvider _dataProvider;

        public OrderedQueryShould()
        {
            _dataProvider = new TestsDataProvider();
        }

        [Fact]
        public async Task ReturnOrderedListBySecondCriteriaAscendantWhenCallingThenBy()
        {
            // arrange
            var entities = new[]
            {
                new TestEntity {Name = "test1", Number = 4},
                new TestEntity {Name = "test1", Number = 3},
                new TestEntity {Name = "test3", Number = 1},
                new TestEntity {Name = "test1", Number = 2}
            };
            _dataProvider.AddEntities(entities);

            // act
            var result = await _dataProvider.ReadOnlyRepository
                .Filter()
                .OrderBy(t => t.Name)
                .ThenBy(t => t.Number)
                .ToListAsync();

            // assert
            Assert.Equal(entities.OrderBy(t => t.Name).ThenBy(t => t.Number), result);
        }

        [Fact]
        public async Task ReturnOrderedListBySecondCriteriaDescendantWhenCallingThenByDescending()
        {
            // arrange
            var entities = new[]
            {
                new TestEntity {Name = "test1", Number = 4},
                new TestEntity {Name = "test1", Number = 3},
                new TestEntity {Name = "test3", Number = 1},
                new TestEntity {Name = "test1", Number = 2}
            };
            _dataProvider.AddEntities(entities);

            // act
            var result = await _dataProvider.ReadOnlyRepository
                .Filter()
                .OrderBy(t => t.Name)
                .ThenByDescending(t => t.Number)
                .ToListAsync();

            // assert
            Assert.Equal(entities.OrderBy(t => t.Name).ThenByDescending(t => t.Number), result);
        }
    }
}
