using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.EfCore.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.EfCore
{
    public class StringTests
    {
        [Fact]
        public void String_IsEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("String_IsEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { StringProperty = "Tom" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Harry" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Pete" });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.StringProperty).IsEqualTo("Tom");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.StringProperty == "Tom");

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void String_IsNotEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("String_IsNotEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { StringProperty = "Tom" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Harry" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Pete" });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.StringProperty).IsNotEqualTo("Tom");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.StringProperty != "Tom");

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void String_In_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("String_In_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { StringProperty = "Tom" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Harry" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Pete" });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.StringProperty).In("Tom", "Harry", "Pete");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => new string[] { "Tom", "Harry", "Pete" }.Contains(i.StringProperty));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void String_NotIn_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("String_NotIn_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { StringProperty = "Tom" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Harry" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Pete" });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.StringProperty).NotIn("Tom", "Harry", "Pete");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !(new string[] { "Tom", "Harry", "Pete" }.Contains(i.StringProperty)));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void String_Contains_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("String_Contains_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { StringProperty = "Tom" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Harry" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Pete" });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.StringProperty).Contains("o");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => (i.StringProperty ?? string.Empty).Contains("o"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void String_StartsWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("String_StartsWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { StringProperty = "Tom" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Harry" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Pete" });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.StringProperty).StartsWith("T");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => (i.StringProperty ?? string.Empty).StartsWith("T"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void String_EndsWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("String_EndsWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { StringProperty = "Tom" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Harry" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Pete" });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.StringProperty).EndsWith("m");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => (i.StringProperty ?? string.Empty).EndsWith("m"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void String_DoesNotContain_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("String_DoesNotContain_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { StringProperty = "Tom" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Harry" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Pete" });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.StringProperty).DoesNotContain("o");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !(i.StringProperty ?? string.Empty).Contains("o"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void String_DoesNotStartWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("String_DoesNotStartWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { StringProperty = "Tom" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Harry" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Pete" });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.StringProperty).DoesNotStartWith("T");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !(i.StringProperty ?? string.Empty).StartsWith("T"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void String_DoesNotEndWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("String_DoesNotEndWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { StringProperty = "Tom" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Harry" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Pete" });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.StringProperty).DoesNotEndWith("m");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !(i.StringProperty ?? string.Empty).EndsWith("m"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void String_IsNull_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("String_IsNull_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { StringProperty = "Tom" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Harry" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Pete" });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.StringProperty).IsNull();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.StringProperty == null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void String_IsNotNull_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("String_IsNotNull_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { StringProperty = "Tom" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Harry" });
                context.TestEntities.Add(new TestEntity() { StringProperty = null });
                context.TestEntities.Add(new TestEntity() { StringProperty = "Pete" });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.StringProperty).IsNotNull();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.StringProperty != null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }
    }
}
