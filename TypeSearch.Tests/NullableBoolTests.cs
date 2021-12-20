using System.Linq;
using System.Collections.Generic;
using Xunit;
using TypeSearch.Tests.Mocks;
using TypeSearch.Providers.Collection;

namespace TypeSearch.Tests
{
    public class NullableBoolTests
    {
        [Fact]
        public void NullableBool_IsEqualTo_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableBoolProperty).IsEqualTo(null);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableBoolProperty == null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableBool_IsNotEqualTo_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableBoolProperty).IsNotEqualTo(null);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableBoolProperty != null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableBool_In_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableBoolProperty).In(new bool?[] { null });
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => new bool?[] { null }.Contains(i.NullableBoolProperty));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableBool_NotIn_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableBoolProperty).NotIn(new bool?[] { null });
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !(new bool?[] { null }.Contains(i.NullableBoolProperty)));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableBool_IsTrue_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableBoolProperty).IsTrue();
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableBoolProperty == true);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableBool_IsFalse_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableBoolProperty).IsFalse();
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableBoolProperty == false);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableBool_IsNull_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableBoolProperty).IsNull();
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableBoolProperty == null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableBool_IsNotNull_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableBoolProperty).IsNotNull();
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableBoolProperty != null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableBool_IsEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableBoolProperty).IsEqualTo(true);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableBoolProperty == true);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableBool_IsNotEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableBoolProperty).IsNotEqualTo(true);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableBoolProperty != true);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableBool_In_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableBoolProperty).In(true);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => new bool?[] { true }.Contains(i.NullableBoolProperty));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableBool_NotIn_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true },
                new TestEntity() { NullableBoolProperty = false },
                new TestEntity() { NullableBoolProperty = null },
                new TestEntity() { NullableBoolProperty = true }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableBoolProperty).NotIn(true);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !(new bool?[] { true }.Contains(i.NullableBoolProperty)));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }
    }
}
