using System.Linq;
using System.Collections.Generic;
using Xunit;
using TypeSearch.Tests.Mocks;
using TypeSearch.Providers.Collection;

namespace TypeSearch.Tests
{
    public class StringTests
    {
        [Fact]
        public void String_IsEqualTo_Search()
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
                .Where(i => i.StringProperty).IsEqualTo("Tom");
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.StringProperty == "Tom");

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void String_IsNotEqualTo_Search()
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
                .Where(i => i.StringProperty).IsNotEqualTo("Tom");
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.StringProperty != "Tom");

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void String_In_Search()
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
                .Where(i => i.StringProperty).In("Tom", "Harry", "Pete");
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => new string[] { "Tom", "Harry", "Pete" }.Contains(i.StringProperty));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void String_NotIn_Search()
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
                .Where(i => i.StringProperty).NotIn("Tom", "Harry", "Pete");
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !(new string[] { "Tom", "Harry", "Pete" }.Contains(i.StringProperty)));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void String_Contains_Search()
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
                .Where(i => i.StringProperty).Contains("o");
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => (i.StringProperty ?? string.Empty).Contains("o"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void String_StartsWith_Search()
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
                .Where(i => i.StringProperty).StartsWith("T");
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => (i.StringProperty ?? string.Empty).StartsWith("T"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void String_EndsWith_Search()
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
                .Where(i => i.StringProperty).EndsWith("m");
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => (i.StringProperty ?? string.Empty).EndsWith("m"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void String_DoesNotContain_Search()
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
                .Where(i => i.StringProperty).DoesNotContain("o");
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !(i.StringProperty ?? string.Empty).Contains("o"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void String_DoesNotStartWith_Search()
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
                .Where(i => i.StringProperty).DoesNotStartWith("T");
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !(i.StringProperty ?? string.Empty).StartsWith("T"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void String_DoesNotEndWith_Search()
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
                .Where(i => i.StringProperty).DoesNotEndWith("m");
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !(i.StringProperty ?? string.Empty).EndsWith("m"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void String_IsNull_Search()
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
                .Where(i => i.StringProperty).IsNull();
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.StringProperty == null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void String_IsNotNull_Search()
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
                .Where(i => i.StringProperty).IsNotNull();
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.StringProperty != null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }
    }
}
