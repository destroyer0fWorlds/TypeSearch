using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.EfCore.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.EfCore
{
    public class DateTimeTests
    {
        [Fact]
        public void DateTime_IsEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DateTime_IsEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTimeProperty).IsEqualTo(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.DateTimeProperty == new DateTime(2007, 7, 21));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void DateTime_IsNotEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DateTime_IsNotEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTimeProperty).IsNotEqualTo(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.DateTimeProperty != new DateTime(2007, 7, 21));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void DateTime_In_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DateTime_In_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) });
                context.SaveChanges();

                var two = new DateTime(2004, 6, 10);
                var three = new DateTime(2007, 7, 21);
                var four = new DateTime(2012, 9, 15);

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTimeProperty).In(two, three, four);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => new DateTime[] { two, three, four }.Contains(i.DateTimeProperty));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void DateTime_NotIn_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DateTime_NotIn_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) });
                context.SaveChanges();

                var two = new DateTime(2004, 6, 10);
                var three = new DateTime(2007, 7, 21);
                var four = new DateTime(2012, 9, 15);

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTimeProperty).NotIn(two, three, four);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !(new DateTime[] { two, three, four }.Contains(i.DateTimeProperty)));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void DateTime_GreaterThan_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DateTime_GreaterThan_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTimeProperty).GreaterThan(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.DateTimeProperty > new DateTime(2007, 7, 21));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void DateTime_GreaterThanOrEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DateTime_GreaterThanOrEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTimeProperty).GreaterThanOrEqualTo(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.DateTimeProperty >= new DateTime(2007, 7, 21));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void DateTime_LessThan_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DateTime_LessThan_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTimeProperty).LessThan(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.DateTimeProperty < new DateTime(2007, 7, 21));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void DateTime_LessThanOrEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DateTime_LessThanOrEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTimeProperty).LessThanOrEqualTo(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.DateTimeProperty <= new DateTime(2007, 7, 21));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void DateTime_Between_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DateTime_Between_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTimeProperty).Between(new DateTime(2004, 6, 10), new DateTime(2012, 9, 15));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.NotEmpty(searchResults.ResultSet);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void DateTime_NotBetween_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DateTime_NotBetween_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTimeProperty).NotBetween(new DateTime(2004, 6, 10), new DateTime(2012, 9, 15));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.NotEmpty(searchResults.ResultSet);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void DateTime_Contains_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DateTime_Contains_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTimeProperty).Contains("2007");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.DateTimeProperty.ToString().Contains("2007"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void DateTime_DoesNotContain_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DateTime_DoesNotContain_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTimeProperty).DoesNotContain("2007");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !i.DateTimeProperty.ToString().Contains("2007"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void DateTime_StartsWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DateTime_StartsWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTimeProperty).StartsWith("2007");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.DateTimeProperty.ToString().StartsWith("2007"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void DateTime_DoesNotStartWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DateTime_DoesNotStartWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTimeProperty).DoesNotStartWith("2007");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !i.DateTimeProperty.ToString().StartsWith("2007"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void DateTime_EndsWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DateTime_EndsWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTimeProperty).EndsWith("PM");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.DateTimeProperty.ToString().EndsWith("PM"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void DateTime_DoesNotEndWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("DateTime_DoesNotEndWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { DateTimeProperty = new DateTime(2016, 11, 7) });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTimeProperty).DoesNotEndWith("PM");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !i.DateTimeProperty.ToString().EndsWith("PM"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }
    }
}
