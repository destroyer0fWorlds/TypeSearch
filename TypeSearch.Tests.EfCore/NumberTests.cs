using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.EfCore.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.EfCore
{
    public class NumberTests
    {
        [Fact]
        public void Int_IsEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Int_IsEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 5 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).IsEqualTo(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.IntProperty == 3);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_IsNotEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Int_IsNotEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 5 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).IsNotEqualTo(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.IntProperty != 3);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_In_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Int_In_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 5 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).In(2, 3, 4);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => new int[] { 2, 3, 4 }.Contains(i.IntProperty));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_NotIn_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Int_NotIn_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 5 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).NotIn(2, 3, 4);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !(new int[] { 2, 3, 4 }.Contains(i.IntProperty)));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_GreaterThan_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Int_GreaterThan_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 5 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).GreaterThan(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.IntProperty > 3);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_GreaterThanOrEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Int_GreaterThanOrEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 5 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).GreaterThanOrEqualTo(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.IntProperty >= 3);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_LessThan_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Int_LessThan_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 5 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).LessThan(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.IntProperty < 3);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_LessThanOrEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Int_LessThanOrEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 5 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).LessThanOrEqualTo(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.IntProperty <= 3);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_Between_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Int_Between_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 5 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).Between(2, 4);
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
        public void Int_NotBetween_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Int_NotBetween_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 4 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 5 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).NotBetween(2, 4);
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
