using System.Linq;
using System.Collections.Generic;
using Xunit;
using TypeSearch.Tests.Mocks;

namespace TypeSearch.Tests
{
    public class NullableNumberTests
    {
        [Fact]
        public void NullableInt_IsEqualTo_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).IsEqualTo(null);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty == null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_IsNotEqualTo_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).IsNotEqualTo(null);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty != null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_In_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).In(new int?[] { null });
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => new int?[] { null }.Contains(i.NullableIntProperty));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_NotIn_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).NotIn(new int?[] { null });
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !(new int?[] { null }.Contains(i.NullableIntProperty)));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_IsNull_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).IsNull();
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty == null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_IsNotNull_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).IsNotNull();
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty != null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_GreaterThan_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).GreaterThan(null);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty > null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_GreaterThanOrEqualTo_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).GreaterThanOrEqualTo(null);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty >= null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_LessThan_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).LessThan(null);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty < null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_LessThanOrEqualTo_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).LessThanOrEqualTo(null);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty <= null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_IsEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).IsEqualTo(3);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty == 3);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_IsNotEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).IsNotEqualTo(3);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty != 3);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_In_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).In(2, 3, 4);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => new int?[] { 2, 3, 4 }.Contains(i.NullableIntProperty));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_NotIn_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).NotIn(2, 3, 4);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !(new int?[] { 2, 3, 4 }.Contains(i.NullableIntProperty)));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_GreaterThan_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).GreaterThan(3);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty > 3);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_GreaterThanOrEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).GreaterThanOrEqualTo(3);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty >= 3);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_LessThan_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).LessThan(3);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty < 3);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_LessThanOrEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).LessThanOrEqualTo(3);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty <= 3);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_Between_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).Between(2, 4);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.NotEmpty(searchResults.ResultSet);
            Assert.Equal(3, searchResults.ResultSet.Count);
            Assert.Equal(3, searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_NotBetween_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 2 },
                new TestEntity() { NullableIntProperty = 3 },
                new TestEntity() { NullableIntProperty = 4 },
                new TestEntity() { NullableIntProperty = 5 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).NotBetween(2, 4);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.NotEmpty(searchResults.ResultSet);
            Assert.Equal(2, searchResults.ResultSet.Count);
            Assert.Equal(2, searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_Contains_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 12 },
                new TestEntity() { NullableIntProperty = 123 },
                new TestEntity() { NullableIntProperty = 1234 },
                new TestEntity() { NullableIntProperty = 12345 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).Contains("3");
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty.ToString().Contains("3"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_DoesNotContain_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 12 },
                new TestEntity() { NullableIntProperty = 123 },
                new TestEntity() { NullableIntProperty = 1234 },
                new TestEntity() { NullableIntProperty = 12345 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).DoesNotContain("3");
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !i.NullableIntProperty.ToString().Contains("3"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_StartsWith_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 12 },
                new TestEntity() { NullableIntProperty = 123 },
                new TestEntity() { NullableIntProperty = 1234 },
                new TestEntity() { NullableIntProperty = 12345 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).StartsWith("1");
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty.ToString().StartsWith("1"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_DoesNotStartWith_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 12 },
                new TestEntity() { NullableIntProperty = 123 },
                new TestEntity() { NullableIntProperty = 1234 },
                new TestEntity() { NullableIntProperty = 12345 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).DoesNotStartWith("1");
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !i.NullableIntProperty.ToString().StartsWith("1"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_EndsWith_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 12 },
                new TestEntity() { NullableIntProperty = 123 },
                new TestEntity() { NullableIntProperty = 1234 },
                new TestEntity() { NullableIntProperty = 12345 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).EndsWith("3");
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableIntProperty.ToString().EndsWith("3"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableInt_DoesNotEndWith_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableIntProperty = 1 },
                new TestEntity() { NullableIntProperty = 12 },
                new TestEntity() { NullableIntProperty = 123 },
                new TestEntity() { NullableIntProperty = 1234 },
                new TestEntity() { NullableIntProperty = 12345 },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null },
                new TestEntity() { NullableIntProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableIntProperty).DoesNotEndWith("3");
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !i.NullableIntProperty.ToString().EndsWith("3"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }
    }
}
