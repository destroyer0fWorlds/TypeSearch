using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace TypeSearch.Tests
{
    public class NullableDateTimeTests
    {
        [Fact]
        public void NullableDateTime_IsEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).IsEqualTo(new DateTime(2007, 7, 21));
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty == new DateTime(2007, 7, 21));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_IsNotEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).IsNotEqualTo(new DateTime(2007, 7, 21));
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty != new DateTime(2007, 7, 21));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_In_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };
            var two = new DateTime(2004, 6, 10);
            var three = new DateTime(2007, 7, 21);
            var four = new DateTime(2012, 9, 15);

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).In(two, three, four);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => new DateTime?[] { two, three, four }.Contains(i.NullableDateTimeProperty));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_NotIn_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };
            var two = new DateTime(2004, 6, 10);
            var three = new DateTime(2007, 7, 21);
            var four = new DateTime(2012, 9, 15);

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).NotIn(two, three, four);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !(new DateTime?[] { two, three, four }.Contains(i.NullableDateTimeProperty)));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_GreaterThan_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).GreaterThan(new DateTime(2007, 7, 21));
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty > new DateTime(2007, 7, 21));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_GreaterThanOrEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).GreaterThanOrEqualTo(new DateTime(2007, 7, 21));
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty >= new DateTime(2007, 7, 21));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_LessThan_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).LessThan(new DateTime(2007, 7, 21));
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty < new DateTime(2007, 7, 21));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_LessThanOrEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).LessThanOrEqualTo(new DateTime(2007, 7, 21));
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty <= new DateTime(2007, 7, 21));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_Between_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).Between(new DateTime(2004, 6, 10), new DateTime(2012, 9, 15));
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.NotEmpty(searchResults.ResultSet);
            Assert.Equal(3, searchResults.ResultSet.Count);
            Assert.Equal(3, searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_NotBetween_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).NotBetween(new DateTime(2004, 6, 10), new DateTime(2012, 9, 15));
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.NotEmpty(searchResults.ResultSet);
            Assert.Equal(2, searchResults.ResultSet.Count);
            Assert.Equal(2, searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_IsEqualTo_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).IsEqualTo(null);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty == null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_IsNotEqualTo_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).IsNotEqualTo(null);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty != null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_IsNull_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).IsNull();
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty == null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_IsNotNull_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).IsNotNull();
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty != null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_In_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };
            var two = new DateTime(2004, 6, 10);
            var three = new DateTime(2007, 7, 21);
            var four = new DateTime(2012, 9, 15);

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).In(new DateTime?[] { null });
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => new DateTime?[] { null }.Contains(i.NullableDateTimeProperty));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_NotIn_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };
            var two = new DateTime(2004, 6, 10);
            var three = new DateTime(2007, 7, 21);
            var four = new DateTime(2012, 9, 15);

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).NotIn(new DateTime?[] { null });
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !(new DateTime?[] { null }.Contains(i.NullableDateTimeProperty)));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_GreaterThan_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).GreaterThan(null);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty > null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_GreaterThanOrEqualTo_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).GreaterThanOrEqualTo(null);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty >= null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_LessThan_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).LessThan(null);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty < null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_LessThanOrEqualTo_Null_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).LessThanOrEqualTo(null);
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty <= null);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_Contains_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).Contains("2007");
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty.ToString().Contains("2007"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_DoesNotContain_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).DoesNotContain("2007");
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !i.NullableDateTimeProperty.ToString().Contains("2007"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_StartsWith_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).StartsWith("2007");
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty.ToString().StartsWith("2007"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_DoesNotStartWith_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).DoesNotStartWith("2007");
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !i.NullableDateTimeProperty.ToString().StartsWith("2007"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_EndsWith_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).EndsWith("PM");
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.NullableDateTimeProperty.ToString().EndsWith("PM"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void NullableDateTime_DoesNotEndWith_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { NullableDateTimeProperty = null },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) },
                new TestEntity() { NullableDateTimeProperty = null }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.NullableDateTimeProperty).DoesNotEndWith("PM");
            var searchResults = new Searcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !i.NullableDateTimeProperty.ToString().EndsWith("PM"));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }
    }
}
