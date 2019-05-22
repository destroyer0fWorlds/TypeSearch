using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;

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
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
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
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
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
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
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
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
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
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
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
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
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
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
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
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
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
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
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
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.NotEmpty(searchResults.ResultSet);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_Contains_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Int_Contains_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 12 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 123 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 1234 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 12345 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).Contains("3");
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.IntProperty.ToString().Contains("3"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_DoesNotContain_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Int_DoesNotContain_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 12 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 123 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 1234 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 12345 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).DoesNotContain("3");
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !i.IntProperty.ToString().Contains("3"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_StartsWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Int_StartsWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 12 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 123 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 1234 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 12345 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).StartsWith("1");
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.IntProperty.ToString().StartsWith("1"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_DoesNotStartWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Int_DoesNotStartWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 12 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 123 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 1234 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 12345 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).DoesNotStartWith("1");
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !i.IntProperty.ToString().StartsWith("1"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_EndsWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Int_EndsWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 12 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 123 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 1234 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 12345 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).EndsWith("3");
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.IntProperty.ToString().EndsWith("3"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_DoesNotEndWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Int_DoesNotEndWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 12 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 123 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 1234 });
                context.TestEntities.Add(new TestEntity() { IntProperty = 12345 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.IntProperty).DoesNotEndWith("3");
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !i.IntProperty.ToString().EndsWith("3"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }
    }
}
