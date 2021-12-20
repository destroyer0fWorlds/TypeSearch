using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.EfCore.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.EfCore
{
    public class NullableDateTimeTests
    {
        [Fact]
        public void NullableDateTime_IsEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_IsEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).IsEqualTo(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableDateTimeProperty == new DateTime(2007, 7, 21));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_IsNotEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_IsNotEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).IsNotEqualTo(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableDateTimeProperty != new DateTime(2007, 7, 21));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_In_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_In_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                var two = new DateTime(2004, 6, 10);
                var three = new DateTime(2007, 7, 21);
                var four = new DateTime(2012, 9, 15);

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).In(two, three, four);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => new DateTime?[] { two, three, four }.Contains(i.NullableDateTimeProperty));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_NotIn_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_NotIn_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                var two = new DateTime(2004, 6, 10);
                var three = new DateTime(2007, 7, 21);
                var four = new DateTime(2012, 9, 15);

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).NotIn(two, three, four);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !(new DateTime?[] { two, three, four }.Contains(i.NullableDateTimeProperty)));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_GreaterThan_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_GreaterThan_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).GreaterThan(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableDateTimeProperty > new DateTime(2007, 7, 21));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_GreaterThanOrEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_GreaterThanOrEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).GreaterThanOrEqualTo(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableDateTimeProperty >= new DateTime(2007, 7, 21));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_LessThan_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_LessThan_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).LessThan(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableDateTimeProperty < new DateTime(2007, 7, 21));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_LessThanOrEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_LessThanOrEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).LessThanOrEqualTo(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableDateTimeProperty <= new DateTime(2007, 7, 21));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_Between_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_Between_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).Between(new DateTime(2004, 6, 10), new DateTime(2012, 9, 15));
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
        public void NullableDateTime_NotBetween_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_NotBetween_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).NotBetween(new DateTime(2004, 6, 10), new DateTime(2012, 9, 15));
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
        public void NullableDateTime_IsEqualTo_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_IsEqualTo_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).IsEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableDateTimeProperty == null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_IsNotEqualTo_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_IsNotEqualTo_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).IsNotEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableDateTimeProperty != null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_IsNull_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_IsNull_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).IsNull();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableDateTimeProperty == null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_IsNotNull_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_IsNotNull_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).IsNotNull();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableDateTimeProperty != null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_In_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_In_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                var two = new DateTime(2004, 6, 10);
                var three = new DateTime(2007, 7, 21);
                var four = new DateTime(2012, 9, 15);

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).In(new DateTime?[] { null });
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => new DateTime?[] { null }.Contains(i.NullableDateTimeProperty));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_NotIn_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_NotIn_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                var two = new DateTime(2004, 6, 10);
                var three = new DateTime(2007, 7, 21);
                var four = new DateTime(2012, 9, 15);

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).NotIn(new DateTime?[] { null });
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !(new DateTime?[] { null }.Contains(i.NullableDateTimeProperty)));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_GreaterThan_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_GreaterThan_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).GreaterThan(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableDateTimeProperty > null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_GreaterThanOrEqualTo_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_GreaterThanOrEqualTo_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).GreaterThanOrEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableDateTimeProperty >= null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_LessThan_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_LessThan_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).LessThan(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableDateTimeProperty < null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_LessThanOrEqualTo_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableDateTime_LessThanOrEqualTo_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                context.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).LessThanOrEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableDateTimeProperty <= null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }
    }
}
