using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace TypeSearch.Tests
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
            var testCollection = new List<ReservedKeywordsTestEntity>()
            {
                new ReservedKeywordsTestEntity() { DateTime = new DateTime(2000, 4, 12) },
                new ReservedKeywordsTestEntity() { DateTime = new DateTime(2004, 6, 10) },
                new ReservedKeywordsTestEntity() { DateTime = new DateTime(2007, 7, 21) },
                new ReservedKeywordsTestEntity() { DateTime = new DateTime(2012, 9, 15) },
                new ReservedKeywordsTestEntity() { DateTime = new DateTime(2016, 11, 7) }
            };

            // Act
            var searchDefinition = new SearchDefinition<ReservedKeywordsTestEntity>();
            searchDefinition.Filter
                .Where(i => i.DateTime).IsEqualTo(new DateTime(2007, 7, 21));
            var searchResults = new Searcher<ReservedKeywordsTestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.DateTime == new DateTime(2007, 7, 21));

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }

        [Fact]
        public void Filtering_By_Property_Named_Parent_Should_Succeed()
        {
            // Arrange
            var testCollection = new List<ReservedKeywordsTestEntity>()
            {
                new ReservedKeywordsTestEntity() { Parent = "yes" },
                new ReservedKeywordsTestEntity() { Parent = "no" },
                new ReservedKeywordsTestEntity() { Parent = "true" },
                new ReservedKeywordsTestEntity() { Parent = "false" },
                new ReservedKeywordsTestEntity() { Parent = "null" }
            };

            // Act
            var searchDefinition = new SearchDefinition<ReservedKeywordsTestEntity>();
            searchDefinition.Filter
                .Where(i => i.Parent).IsEqualTo("true");
            var searchResults = new Searcher<ReservedKeywordsTestEntity>(testCollection.AsQueryable())
                .Search(searchDefinition);

            var expectedResults = testCollection.Where(i => i.Parent == "true");

            // Assert
            Assert.NotNull(searchResults.ResultSet);
            Assert.Equal(expectedResults.Count(), searchResults.ResultSet.Count);
            Assert.Equal(expectedResults.Count(), searchResults.FilteredRecordCount);
        }
    }
}
