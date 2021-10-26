using System.Linq;
using System.Collections.Generic;
using Xunit;
using TypeSearch.Tests.Mocks;

namespace TypeSearch.Tests
{
    public class CaseSensitivityTests
    {
        [Fact]
        public void LinqToObjects_Is_Case_Sensitive()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { StringProperty = "Tom" },
                new TestEntity() { StringProperty = null },
                new TestEntity() { StringProperty = "Harry" },
                new TestEntity() { StringProperty = null },
                new TestEntity() { StringProperty = "Pete" }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.StringProperty).IsEqualTo("tom");
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.StringProperty == "tom");

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Empty(searchResults.ResultSet);
            Assert.Empty(expectedResults);
        }
    }
}
