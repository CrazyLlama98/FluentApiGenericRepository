using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FluentApiGenericRepository.Test.QueryTests
{
    public class QueryShould
    {
        private readonly TestsDataProvider _dataProvider;

        public QueryShould()
        {
            _dataProvider = new TestsDataProvider();
        }

        [Fact]
        public async Task ReturnCorrectEntitiesWhenCallingSelect()
        {
            // arrange
            var entities = new[]
            {
                new TestEntity {Id = Guid.NewGuid()}, 
                new TestEntity {Id = Guid.NewGuid()},
                new TestEntity {Id = Guid.NewGuid()}
            };
            _dataProvider.AddEntities(entities);

            // act
            var result = await _dataProvider.ReadOnlyRepository
                .Filter()
                .Select(t => t.Id)
                .ToListAsync();

            // assert
            Assert.Equal(entities.Select(e => e.Id), result);
        }

        [Fact]
        public async Task ReturnOrderedEntitiesByNameWhenCallingOrderBy()
        {
            // arrange
            var entities = new[]
            {
                new TestEntity {Name = "test3"}, 
                new TestEntity {Name = "test1"},
                new TestEntity {Name = "test2"}
            };
            _dataProvider.AddEntities(entities);

            // act
            var result = await _dataProvider.ReadOnlyRepository
                .Filter()
                .OrderBy(test => test.Name)
                .ToListAsync();

            // assert
            Assert.Equal(entities.OrderBy(test => test.Name), result);
        }

        [Fact]
        public async Task ReturnOrderedEntitiesByNameWhenCallingOrderByDescending()
        {
            // arrange
            var entities = new[]
            {
                new TestEntity {Name = "test1"}, 
                new TestEntity {Name = "test2"},
                new TestEntity {Name = "test3"}
            };
            _dataProvider.AddEntities(entities);

            // act
            var result = await _dataProvider.ReadOnlyRepository
                .Filter()
                .OrderByDescending(test => test.Name)
                .ToListAsync();

            // assert
            Assert.Equal(entities.OrderByDescending(test => test.Name), result);
        }

        [Fact]
        public async Task ReturnNotNullSubEntityWhenCallingInclude()
        {
            // arrange
            var subEntities = new[]
            {
                new SubEntity { Name = "subEntity1" },
                new SubEntity { Name = "SubEntity2" }
            };
            var entities = new[]
            {
                new TestEntity {Name = "test1", SubEntities = subEntities}, 
                new TestEntity {Name = "test2"},
                new TestEntity {Name = "test3"}
            };
            _dataProvider.AddEntities(entities);
            
            // act
            var result = await _dataProvider.ReadOnlyRepository
                .Filter()
                .Include(test => test.SubEntities)
                .FirstOrDefaultAsync(test => test.Name == "test1");
            
            // assert
            Assert.NotNull(result.SubEntities);
        }
    }
}
