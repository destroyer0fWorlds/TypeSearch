using System.Linq;
using System.Collections.Generic;
using Xunit;
using TypeSearch.Tests.Mocks;
using TypeSearch.Providers.Collection;

namespace TypeSearch.Tests
{
    public class BoolTests
    {
        [Fact]
        public void Bool_IsEqualTo_Search()
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
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.BoolProperty).IsEqualTo(true);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.BoolProperty == true);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Bool_IsNotEqualTo_Search()
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
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.BoolProperty).IsNotEqualTo(true);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.BoolProperty != true);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Bool_In_Search()
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
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.BoolProperty).In(true);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => new bool[] { true }.Contains(i.BoolProperty));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Bool_NotIn_Search()
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
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.BoolProperty).NotIn(true);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !(new bool[] { true }.Contains(i.BoolProperty)));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Bool_IsTrue_Search()
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
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.BoolProperty).IsTrue();
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.BoolProperty);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Bool_IsFalse_Search()
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
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.BoolProperty).IsFalse();
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !i.BoolProperty);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }
    }
}
