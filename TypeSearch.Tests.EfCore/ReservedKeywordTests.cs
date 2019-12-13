using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace TypeSearch.Tests.EfCore
{
    // The core library (https://github.com/StefH/System.Linq.Dynamic.Core) has reserved keywords that cannot be property names.
    // I don't know all of them but "DateTime" came up once during testing and is remarked on here: https://github.com/StefH/System.Linq.Dynamic.Core/issues/182
    // The solution was to append an "@" symbol

    public class ReservedKeywordTests
    {
        [Fact]
        public void Filtering_By_Property_Named_DateTime_Should_Succeed()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Filtering_By_Property_Named_DateTime_Should_Succeed")
                .Options;

            using (var context = new TestContext(options))
            {
                context.ReservedKeywordsTestEntities.Add(new ReservedKeywordsTestEntity() { DateTime = new DateTime(2000, 4, 12) });
                context.ReservedKeywordsTestEntities.Add(new ReservedKeywordsTestEntity() { DateTime = new DateTime(2004, 6, 10) });
                context.ReservedKeywordsTestEntities.Add(new ReservedKeywordsTestEntity() { DateTime = new DateTime(2007, 7, 21) });
                context.ReservedKeywordsTestEntities.Add(new ReservedKeywordsTestEntity() { DateTime = new DateTime(2012, 9, 15) });
                context.ReservedKeywordsTestEntities.Add(new ReservedKeywordsTestEntity() { DateTime = new DateTime(2016, 11, 7) });
                context.SaveChanges();
            }

            using (var context = new TestContext(options))
            {
                // Act
                var searchDefinition = new SearchDefinition<ReservedKeywordsTestEntity>();
                searchDefinition.Filter
                    .Where(i => i.DateTime).IsEqualTo(new DateTime(2007, 7, 21));
                var searchResults = new Searcher<ReservedKeywordsTestEntity>(context.ReservedKeywordsTestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.ReservedKeywordsTestEntities.Where(i => i.DateTime == new DateTime(2007, 7, 21));

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Filtering_By_Property_Named_Parent_Should_Succeed()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Filtering_By_Property_Named_Parent_Should_Succeed")
                .Options;

            using (var context = new TestContext(options))
            {
                context.ReservedKeywordsTestEntities.Add(new ReservedKeywordsTestEntity() { Parent = "yes" });
                context.ReservedKeywordsTestEntities.Add(new ReservedKeywordsTestEntity() { Parent = "no" });
                context.ReservedKeywordsTestEntities.Add(new ReservedKeywordsTestEntity() { Parent = "true" });
                context.ReservedKeywordsTestEntities.Add(new ReservedKeywordsTestEntity() { Parent = "false" });
                context.ReservedKeywordsTestEntities.Add(new ReservedKeywordsTestEntity() { Parent = "null" });
                context.SaveChanges();
            }

            using (var context = new TestContext(options))
            {
                // Act
                var searchDefinition = new SearchDefinition<ReservedKeywordsTestEntity>();
                searchDefinition.Filter
                    .Where(i => i.Parent).IsEqualTo("true");
                var searchResults = new Searcher<ReservedKeywordsTestEntity>(context.ReservedKeywordsTestEntities)
                    .Search(searchDefinition);

                var expectedResults = context.ReservedKeywordsTestEntities.Where(i => i.Parent == "true");

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
                Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
            }
        }
    }
}
