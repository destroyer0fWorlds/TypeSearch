using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.EfCore.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.EfCore
{
    public class NullableBoolTests
    {
        [Fact]
        public void NullableBool_IsEqualTo_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_IsEqualTo_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).IsEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableBoolProperty == null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_IsNotEqualTo_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_IsNotEqualTo_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).IsNotEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableBoolProperty != null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_In_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_In_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).In(new bool?[] { null });
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => new bool?[] { null }.Contains(i.NullableBoolProperty));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_NotIn_Null_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_NotIn_Null_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).NotIn(new bool?[] { null });
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !(new bool?[] { null }.Contains(i.NullableBoolProperty)));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_IsTrue_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_IsTrue_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).IsTrue();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableBoolProperty == true);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_IsFalse_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_IsFalse_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).IsFalse();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableBoolProperty == false);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_IsNull_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_IsNull_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).IsNull();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableBoolProperty == null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_IsNotNull_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_IsNotNull_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).IsNotNull();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableBoolProperty != null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_IsEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_IsEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).IsEqualTo(true);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableBoolProperty == true);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_IsNotEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_IsNotEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).IsNotEqualTo(true);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableBoolProperty != true);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_In_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_In_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).In(true);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => new bool?[] { true }.Contains(i.NullableBoolProperty));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_NotIn_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_NotIn_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).NotIn(true);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !(new bool?[] { true }.Contains(i.NullableBoolProperty)));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_Contains_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_Contains_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).Contains("ru");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableBoolProperty.ToString().Contains("ru"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_DoesNotContain_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_DoesNotContain_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).DoesNotContain("ru");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !i.NullableBoolProperty.GetValueOrDefault(false).ToString().Contains("ru"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_StartsWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_StartsWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).StartsWith("t");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableBoolProperty.ToString().StartsWith("t"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_DoesNotStartWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_DoesNotStartWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).DoesNotStartWith("t");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !i.NullableBoolProperty.GetValueOrDefault(false).ToString().StartsWith("t"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_EndsWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_EndsWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).EndsWith("ue");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.NullableBoolProperty.ToString().EndsWith("ue"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_DoesNotEndWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("NullableBool_DoesNotEndWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                context.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableBoolProperty).DoesNotEndWith("ue");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !i.NullableBoolProperty.GetValueOrDefault(false).ToString().EndsWith("ue"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }
    }
}
