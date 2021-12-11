using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
using TypeSearch.Tests.SQLite.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.SQLite
{
    public class CaseSensitivityTests
    {
        [Fact]
        public void Lowercase_Search_Should_Return_Uppercase_Results()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act                
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.StringProperty).Contains("lorem"); // LOREM
                var searcher = new EFCoreSearcher<TestEntity>(context.TestEntities);
                var searchResults = searcher.Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Single(searchResults.ResultSet);
                Assert.Equal(3, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Uppercase_Search_Should_Return_Lowercase_Results()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act                
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.StringProperty).Contains("IPSUM"); // ipsum
                var searcher = new EFCoreSearcher<TestEntity>(context.TestEntities);
                var searchResults = searcher.Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Single(searchResults.ResultSet);
                Assert.Equal(3, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Mismatched_Casing_Search_Should_Return_Expected_Results()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act                
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.StringProperty).Contains("doLOR"); // DoLoR
                var searcher = new EFCoreSearcher<TestEntity>(context.TestEntities);
                var searchResults = searcher.Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Single(searchResults.ResultSet);
                Assert.Equal(3, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.FilteredRecordCount);
            }
        }

        TestContext GetTestContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite()
                .Options;

            var dbName = $"TypeSearch_UnitTests_SQLite_{nameof(CaseSensitivityTests)}";
            var db = new TestContext(options, dbName);

            db.Database.EnsureCreated();

            // Ensure the db has records in it before attempting to search
            var testEntity = db.TestEntities.FirstOrDefault();
            if (testEntity == null)
            {
                db.TestEntities.AddRange(
                    new TestEntity() { StringProperty = "LOREM" },
                    new TestEntity() { StringProperty = "ipsum" },
                    new TestEntity() { StringProperty = "DoLoR" });
                db.SaveChanges();
            }

            return db;
        }
    }
}
