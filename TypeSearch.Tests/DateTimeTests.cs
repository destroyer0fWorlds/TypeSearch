using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using TypeSearch.Tests.Mocks;
using TypeSearch.Providers.Collection;

namespace TypeSearch.Tests
{
    public class DateTimeTests
    {
        [Fact]
        public void DateTime_IsEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.DateTimeProperty).IsEqualTo(new DateTime(2007, 7, 21));
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.DateTimeProperty == new DateTime(2007, 7, 21));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void DateTime_IsNotEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.DateTimeProperty).IsNotEqualTo(new DateTime(2007, 7, 21));
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.DateTimeProperty != new DateTime(2007, 7, 21));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void DateTime_In_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) }
            };
            var two = new DateTime(2004, 6, 10);
            var three = new DateTime(2007, 7, 21);
            var four = new DateTime(2012, 9, 15);

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.DateTimeProperty).In(two, three, four);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => new DateTime[] { two, three, four }.Contains(i.DateTimeProperty));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void DateTime_NotIn_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) }
            };
            var two = new DateTime(2004, 6, 10);
            var three = new DateTime(2007, 7, 21);
            var four = new DateTime(2012, 9, 15);

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.DateTimeProperty).NotIn(two, three, four);
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => !(new DateTime[] { two, three, four }.Contains(i.DateTimeProperty)));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void DateTime_GreaterThan_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.DateTimeProperty).GreaterThan(new DateTime(2007, 7, 21));
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.DateTimeProperty > new DateTime(2007, 7, 21));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void DateTime_GreaterThanOrEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.DateTimeProperty).GreaterThanOrEqualTo(new DateTime(2007, 7, 21));
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.DateTimeProperty >= new DateTime(2007, 7, 21));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void DateTime_LessThan_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.DateTimeProperty).LessThan(new DateTime(2007, 7, 21));
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.DateTimeProperty < new DateTime(2007, 7, 21));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void DateTime_LessThanOrEqualTo_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.DateTimeProperty).LessThanOrEqualTo(new DateTime(2007, 7, 21));
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.DateTimeProperty <= new DateTime(2007, 7, 21));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void DateTime_Between_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.DateTimeProperty).Between(new DateTime(2004, 6, 10), new DateTime(2012, 9, 15));
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.NotEmpty(searchResults.ResultSet);
            Assert.Equal(3, searchResults.ResultSet.Count);
            Assert.Equal(3, searchResults.FilteredRecordCount);
        }

        [Fact]
        public void DateTime_NotBetween_Search()
        {
            // Arrange
            var testCollection = new List<TestEntity>()
            {
                new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) },
                new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) },
                new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) },
                new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) },
                new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) }
            };

            // Act
            var searchDefinition = new SearchDefinition<TestEntity>();
            searchDefinition.Filter
                .Where(i => i.DateTimeProperty).NotBetween(new DateTime(2004, 6, 10), new DateTime(2012, 9, 15));
            var searchResults = new CollectionSearcher<TestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.NotEmpty(searchResults.ResultSet);
            Assert.Equal(2, searchResults.ResultSet.Count);
            Assert.Equal(2, searchResults.FilteredRecordCount);
        }
    }
}
