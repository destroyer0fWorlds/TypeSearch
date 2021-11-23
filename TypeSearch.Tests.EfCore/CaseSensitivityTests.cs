using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.EfCore.Mocks;

namespace TypeSearch.Tests.EfCore
{
    public class CaseSensitivityTests
    {
        // EXCEPT this isn't LINQ to SQL, it is an in-memory database and every query is evaluated client-side
        //[Fact]
        public void LinqToSql_Is_Not_Case_Sensitive()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("LinqToSql_Is_Not_Case_Sensitive")
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
                    .Where(i => i.StringProperty).IsEqualTo("tom");
                var searchResults = new Searcher<TestEntity>(context.TestEntities)
                    .Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(1, searchResults.ResultSet.Count);
                Assert.Equal(1, searchResults.FilteredRecordCount);
            }
        }
    }
}
