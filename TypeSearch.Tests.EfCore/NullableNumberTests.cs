using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.EfCore.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.EfCore
{
    public class NullableNumberTests
    {
        [Fact]
        public void NullableInt_IsEqualTo_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_IsEqualTo_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).IsEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableIntProperty == null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_IsNotEqualTo_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_IsNotEqualTo_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).IsNotEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableIntProperty != null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_In_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_In_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).In(new int?[] { null });
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => new int?[] { null }.Contains(i.NullableIntProperty));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_NotIn_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_NotIn_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).NotIn(new int?[] { null });
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !(new int?[] { null }.Contains(i.NullableIntProperty)));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_IsNull_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_IsNull_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).IsNull();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableIntProperty == null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_IsNotNull_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_IsNotNull_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).IsNotNull();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableIntProperty != null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_GreaterThan_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_GreaterThan_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).GreaterThan(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableIntProperty > null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_GreaterThanOrEqualTo_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_GreaterThanOrEqualTo_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).GreaterThanOrEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableIntProperty >= null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_LessThan_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_LessThan_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).LessThan(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableIntProperty < null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_LessThanOrEqualTo_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_LessThanOrEqualTo_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).LessThanOrEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableIntProperty <= null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_IsEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_IsEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).IsEqualTo(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableIntProperty == 3);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_IsNotEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_IsNotEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).IsNotEqualTo(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableIntProperty != 3);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_In_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_In_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).In(2, 3, 4);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => new int?[] { 2, 3, 4 }.Contains(i.NullableIntProperty));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_NotIn_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_NotIn_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).NotIn(2, 3, 4);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !(new int?[] { 2, 3, 4 }.Contains(i.NullableIntProperty)));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_GreaterThan_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_GreaterThan_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).GreaterThan(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableIntProperty > 3);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_GreaterThanOrEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_GreaterThanOrEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).GreaterThanOrEqualTo(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableIntProperty >= 3);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_LessThan_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_LessThan_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).LessThan(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableIntProperty < 3);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_LessThanOrEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_LessThanOrEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).LessThanOrEqualTo(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableIntProperty <= 3);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_Between_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_Between_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).Between(2, 4);
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
        public void NullableInt_NotBetween_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableInt_NotBetween_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = 5 });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableIntProperty).NotBetween(2, 4);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.NotEmpty(searchResults.ResultSet);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }
    }
}
