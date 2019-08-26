using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FluentApiGenericRepository.Test.QueryTests
{
    public class BaseQueryShould
    {
        private readonly TestsDataProvider _dataProvider;

        public BaseQueryShould()
        {
            _dataProvider = new TestsDataProvider();
        }

        [Fact]
        public async Task ReturnAllEntitiesWhenNoFilterIsUsed()
        {
            // arrange
            var expectedCount = 3;
            _dataProvider.AddEntities(new TestEntity(), new TestEntity(), new TestEntity());

            // act
            var result = await _dataProvider.ReadOnlyRepository.Filter().ToListAsync();

            // assert
            Assert.Equal(expectedCount, result.Count());
        }

        [Fact]
        public async Task ReturnAllEntitiesMatchingAFilter()
        {
            // arrange
            var expectedCount = 2;
            _dataProvider.AddEntities(new TestEntity { Name = "test1" }, new TestEntity { Name = "test2" }, new TestEntity { Name = "tset3" });

            // act
            var result = await _dataProvider.ReadOnlyRepository
                .Filter()
                .Where(t => t.Name.StartsWith("test"))
                .ToListAsync();

            // assert
            Assert.Equal(expectedCount, result.Count());
        }

        [Fact]
        public async Task ReturnCorrectCountWhenCallingCountAsync()
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
                .CountAsync();

            // assert
            Assert.Equal(entities.Length, result);
        }

        [Fact]
        public async Task ReturnTopEntitiesWhenCallingTake()
        {
            // arrange
            var entities = new[]
            {
                new TestEntity {Name = "test1"},
                new TestEntity {Name = "test2"},
                new TestEntity {Name = "test3"},
                new TestEntity {Name = "test4"} 
            };
            _dataProvider.AddEntities(entities);

            // act
            var result = await _dataProvider.ReadOnlyRepository
                .Filter()
                .Take(2)
                .ToListAsync();

            // assert
            Assert.Equal(entities.Take(2), result);
        }

        [Fact]
        public async Task SkipFirstEntitiesWhenCallingSkip()
        {
            // arrange
            var entities = new[]
            {
                new TestEntity {Name = "test1"},
                new TestEntity {Name = "test2"},
                new TestEntity {Name = "test3"},
                new TestEntity {Name = "test4"} 
            };
            _dataProvider.AddEntities(entities);

            // act
            var result = await _dataProvider.ReadOnlyRepository
                .Filter()
                .Skip(2)
                .ToListAsync();

            // assert
            Assert.Equal(entities.Skip(2), result);
        }

        [Fact]
        public async Task ReturnFirstElementWhenCallingFirstOrDefault()
        {
            // arrange
            var entities = new[]
            {
                new TestEntity {Name = "test1"}, 
                new TestEntity {Name = "test12"},
                new TestEntity {Name = "test3"}
            };
            _dataProvider.AddEntities(entities);

            // act
            var result = await _dataProvider.ReadOnlyRepository
                .Filter()
                .FirstOrDefaultAsync(test => test.Name.StartsWith("test1"));

            // assert
            Assert.Equal(entities[0], result);
        }

        [Fact]
        public async Task ReturnNullWhenCallingFirstOrDefaultAndEntityIsNotFound()
        {
            // arrange
            var entities = new[]
            {
                new TestEntity {Name = "test1"}, 
                new TestEntity {Name = "test12"},
                new TestEntity {Name = "test3"}
            };
            _dataProvider.AddEntities(entities);

            // act
            var result = await _dataProvider.ReadOnlyRepository
                .Filter()
                .FirstOrDefaultAsync(test => test.Name.StartsWith("not_test"));

            // assert
            Assert.Null(result);
        }

        [Fact]
        public async Task ReturnFirstElementWhenCallingFirst()
        {
            // arrange
            var entities = new[]
            {
                new TestEntity {Name = "test1"}, 
                new TestEntity {Name = "test12"},
                new TestEntity {Name = "test3"}
            };
            _dataProvider.AddEntities(entities);

            // act
            var result = await _dataProvider.ReadOnlyRepository
                .Filter()
                .FirstAsync(test => test.Name.StartsWith("test1"));

            // assert
            Assert.Equal(entities[0], result);
        }

        [Fact]
        public async Task ThrowExceptionWhenCallingFirstAndEntityIsNotFound()
        {
            // arrange
            var entities = new[]
            {
                new TestEntity {Name = "test1"}, 
                new TestEntity {Name = "test12"},
                new TestEntity {Name = "test3"}
            };
            _dataProvider.AddEntities(entities);

            // act & assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _dataProvider.ReadOnlyRepository
                    .Filter()
                    .FirstAsync(test => test.Name.StartsWith("not_test")));
        }
    }
}
