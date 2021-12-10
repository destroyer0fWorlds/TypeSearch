using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.EfCore.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.EfCore
{
    public class BoolTests
    {
        [Fact]
        public void Bool_IsEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Bool_IsEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.SaveChanges();
            
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.BoolProperty).IsEqualTo(true);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.BoolProperty == true).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Bool_IsNotEqualTo_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Bool_IsNotEqualTo_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.BoolProperty).IsNotEqualTo(true);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.BoolProperty != true).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Bool_In_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Bool_In_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.BoolProperty).In(true);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => new bool[] { true }.Contains(i.BoolProperty)).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Bool_NotIn_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Bool_NotIn_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.BoolProperty).NotIn(true);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !(new bool[] { true }.Contains(i.BoolProperty))).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Bool_IsTrue_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Bool_IsTrue_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.BoolProperty).IsTrue();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.BoolProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Bool_IsFalse_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Bool_IsFalse_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.BoolProperty).IsFalse();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !i.BoolProperty).ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Bool_Contains_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Bool_Contains_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.SaveChanges();

                // Act
                var expectedResults = context.TestEntities.Where(i => DbFunctionsExtensions.Like(EF.Functions, i.BoolProperty.ToString(), "%ru%"));
                var expectedResults2 = context.TestEntities.Where(i => EF.Functions.Like(i.BoolProperty.ToString(), "%ru%"));

                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.BoolProperty).Contains("ru");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                //var expectedResults = context.TestEntities.Where(i => i.BoolProperty.ToString().Contains("ru"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Bool_DoesNotContain_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Bool_DoesNotContain_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.BoolProperty).DoesNotContain("ru");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !i.BoolProperty.ToString().Contains("ru"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Bool_StartsWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Bool_StartsWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.BoolProperty).StartsWith("t");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.BoolProperty.ToString().StartsWith("t"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Bool_DoesNotStartWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Bool_DoesNotStartWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.BoolProperty).DoesNotStartWith("t");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !i.BoolProperty.ToString().StartsWith("t"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Bool_EndsWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Bool_EndsWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.BoolProperty).EndsWith("ue");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.BoolProperty.ToString().EndsWith("ue"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Bool_DoesNotEndWith_Search()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Bool_DoesNotEndWith_Search")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.BoolProperty).DoesNotEndWith("ue");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => !i.BoolProperty.ToString().EndsWith("ue"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }
    }
}
