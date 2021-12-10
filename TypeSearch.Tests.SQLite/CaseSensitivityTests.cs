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
        public void String_Contains_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act                
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.StringProperty).Contains("lorem"); // Lorem
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                //var expectedResults = context.TestEntities.Where(i => DbFunctionsExtensions.Like(EF.Functions, i.StringProperty, "%lorem%"));
                var expectedResults = context.TestEntities.Where(i => EF.Functions.Like(i.StringProperty, "%lorem%"));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        TestContext GetTestContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite()
                .Options;

            var db = new TestContext(options);

            db.Database.EnsureCreated();

            // Ensure the db has records in it before attempting to search
            var testEntity = db.TestEntities.FirstOrDefault();
            if (testEntity == null)
            {
                db.TestEntities.AddRange(
                    new TestEntity() { StringProperty = "Lorem" },
                    new TestEntity() { StringProperty = "ipsum" },
                    new TestEntity() { StringProperty = "dolor" },
                    new TestEntity() { StringProperty = "sit" },
                    new TestEntity() { StringProperty = "amet" });
                db.SaveChanges();
            }

            return db;
        }
    }
}
