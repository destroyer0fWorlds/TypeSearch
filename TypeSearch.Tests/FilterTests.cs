using System.Linq;
using System.Collections.Generic;
using Xunit;
using TypeSearch.Tests.Mocks;

namespace TypeSearch.Tests
{
    public class FilterTests
    {
        [Fact]
        public void Filter_Ignores_Paging()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { BoolProperty = true },
                new TestEntity() { BoolProperty = false },
                new TestEntity() { BoolProperty = true },
                new TestEntity() { BoolProperty = false },
                new TestEntity() { BoolProperty = true }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>(page: 3, recordsPerPage: 1);
            searchDefinition.Filter.Where(i => i.BoolProperty).IsTrue();
            var filterResults = new Searcher<TestEntity>(testCollection.AsQueryable()).Filter(searchDefinition);

            var expectedResults = testCollection.Where(i => i.BoolProperty);

            // Assert
            Assert.NotNull(filterResults);
            Assert.NotEmpty(filterResults);
            Assert.Equal(expectedResults.Count(), filterResults.Count());
        }

        [Fact]
        public void Filter_Ignores_Sorting()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { BoolProperty = true, IntProperty = 0 },
                new TestEntity() { BoolProperty = false, IntProperty = 1 },
                new TestEntity() { BoolProperty = true, IntProperty = 2 },
                new TestEntity() { BoolProperty = false, IntProperty = 3 },
                new TestEntity() { BoolProperty = true, IntProperty = 4 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter.Where(i => i.BoolProperty).IsTrue();
            searchDefinition.Sort.DescendingBy(i => i.IntProperty);
            var filterResults = new Searcher<TestEntity>(testCollection.AsQueryable()).Filter(searchDefinition);

            var expectedResults = testCollection.Where(i => i.BoolProperty);

            // Assert
            Assert.NotNull(filterResults);
            Assert.NotEmpty(filterResults);
            Assert.Equal(expectedResults.Count(), filterResults.Count());
            Assert.Equal(expectedResults.ElementAt(0).IntProperty, filterResults.ElementAt(0).IntProperty);
            Assert.Equal(expectedResults.ElementAt(1).IntProperty, filterResults.ElementAt(1).IntProperty);
            Assert.Equal(expectedResults.ElementAt(2).IntProperty, filterResults.ElementAt(2).IntProperty);
        }
    }
}
