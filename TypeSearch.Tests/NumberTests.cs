using System.Linq;
using System.Collections.Generic;
using Xunit;
using TypeSearch.Tests.Mocks;
using TypeSearch.Providers.Collection;

namespace TypeSearch.Tests
{
    public class NumberTests
    {
        [Fact]
        public void Int_IsEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { IntProperty = 1 },
                new TestEntity() { IntProperty = 2 },
                new TestEntity() { IntProperty = 3 },
                new TestEntity() { IntProperty = 4 },
                new TestEntity() { IntProperty = 5 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.IntProperty).IsEqualTo(3);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.IntProperty == 3);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Int_IsNotEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { IntProperty = 1 },
                new TestEntity() { IntProperty = 2 },
                new TestEntity() { IntProperty = 3 },
                new TestEntity() { IntProperty = 4 },
                new TestEntity() { IntProperty = 5 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.IntProperty).IsNotEqualTo(3);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.IntProperty != 3);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Int_In_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { IntProperty = 1 },
                new TestEntity() { IntProperty = 2 },
                new TestEntity() { IntProperty = 3 },
                new TestEntity() { IntProperty = 4 },
                new TestEntity() { IntProperty = 5 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.IntProperty).In(2, 3, 4);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => new int[] { 2, 3, 4 }.Contains(i.IntProperty));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Int_NotIn_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { IntProperty = 1 },
                new TestEntity() { IntProperty = 2 },
                new TestEntity() { IntProperty = 3 },
                new TestEntity() { IntProperty = 4 },
                new TestEntity() { IntProperty = 5 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.IntProperty).NotIn(2, 3, 4);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !(new int[] { 2, 3, 4 }.Contains(i.IntProperty)));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Int_GreaterThan_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { IntProperty = 1 },
                new TestEntity() { IntProperty = 2 },
                new TestEntity() { IntProperty = 3 },
                new TestEntity() { IntProperty = 4 },
                new TestEntity() { IntProperty = 5 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.IntProperty).GreaterThan(3);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.IntProperty > 3);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Int_GreaterThanOrEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { IntProperty = 1 },
                new TestEntity() { IntProperty = 2 },
                new TestEntity() { IntProperty = 3 },
                new TestEntity() { IntProperty = 4 },
                new TestEntity() { IntProperty = 5 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.IntProperty).GreaterThanOrEqualTo(3);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.IntProperty >= 3);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Int_LessThan_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { IntProperty = 1 },
                new TestEntity() { IntProperty = 2 },
                new TestEntity() { IntProperty = 3 },
                new TestEntity() { IntProperty = 4 },
                new TestEntity() { IntProperty = 5 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.IntProperty).LessThan(3);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.IntProperty < 3);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Int_LessThanOrEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { IntProperty = 1 },
                new TestEntity() { IntProperty = 2 },
                new TestEntity() { IntProperty = 3 },
                new TestEntity() { IntProperty = 4 },
                new TestEntity() { IntProperty = 5 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.IntProperty).LessThanOrEqualTo(3);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.IntProperty <= 3);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Int_Between_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { IntProperty = 1 },
                new TestEntity() { IntProperty = 2 },
                new TestEntity() { IntProperty = 3 },
                new TestEntity() { IntProperty = 4 },
                new TestEntity() { IntProperty = 5 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.IntProperty).Between(2, 4);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.NotEmpty(searchResults.ResultSet);
            Assert.Equal(3, searchResults.ResultSet.Count);
            Assert.Equal(3, searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Int_NotBetween_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { IntProperty = 1 },
                new TestEntity() { IntProperty = 2 },
                new TestEntity() { IntProperty = 3 },
                new TestEntity() { IntProperty = 4 },
                new TestEntity() { IntProperty = 5 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.IntProperty).NotBetween(2, 4);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.NotEmpty(searchResults.ResultSet);
            Assert.Equal(2, searchResults.ResultSet.Count);
            Assert.Equal(2, searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Int_Contains_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { IntProperty = 1 },
                new TestEntity() { IntProperty = 12 },
                new TestEntity() { IntProperty = 123 },
                new TestEntity() { IntProperty = 1234 },
                new TestEntity() { IntProperty = 12345 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.IntProperty).Contains("3");
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.IntProperty.ToString().Contains("3"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Int_DoesNotContain_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { IntProperty = 1 },
                new TestEntity() { IntProperty = 12 },
                new TestEntity() { IntProperty = 123 },
                new TestEntity() { IntProperty = 1234 },
                new TestEntity() { IntProperty = 12345 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.IntProperty).DoesNotContain("3");
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !i.IntProperty.ToString().Contains("3"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Int_StartsWith_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { IntProperty = 1 },
                new TestEntity() { IntProperty = 12 },
                new TestEntity() { IntProperty = 123 },
                new TestEntity() { IntProperty = 1234 },
                new TestEntity() { IntProperty = 12345 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.IntProperty).StartsWith("1");
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.IntProperty.ToString().StartsWith("1"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Int_DoesNotStartWith_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { IntProperty = 1 },
                new TestEntity() { IntProperty = 12 },
                new TestEntity() { IntProperty = 123 },
                new TestEntity() { IntProperty = 1234 },
                new TestEntity() { IntProperty = 12345 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.IntProperty).DoesNotStartWith("1");
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !i.IntProperty.ToString().StartsWith("1"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Int_EndsWith_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { IntProperty = 1 },
                new TestEntity() { IntProperty = 12 },
                new TestEntity() { IntProperty = 123 },
                new TestEntity() { IntProperty = 1234 },
                new TestEntity() { IntProperty = 12345 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.IntProperty).EndsWith("3");
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.IntProperty.ToString().EndsWith("3"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Int_DoesNotEndWith_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { IntProperty = 1 },
                new TestEntity() { IntProperty = 12 },
                new TestEntity() { IntProperty = 123 },
                new TestEntity() { IntProperty = 1234 },
                new TestEntity() { IntProperty = 12345 }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.IntProperty).DoesNotEndWith("3");
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !i.IntProperty.ToString().EndsWith("3"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }
    }
}
