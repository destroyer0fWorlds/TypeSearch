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
    }
}
