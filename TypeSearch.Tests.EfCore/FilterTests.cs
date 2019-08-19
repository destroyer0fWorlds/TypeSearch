using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace TypeSearch.Tests.EfCore
{
    public class FilterTests
    {
        [Fact]
        public void Filter_Ignores_Paging()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Filter_Ignores_Paging")
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
                var searchDefinition = new SearchDefinition<TestEntity>(page: 3, recordsPerPage: 1);
                searchDefinition.Filter.Where(i => i.BoolProperty).IsTrue();
                var filterResults = new Searcher<TestEntity>(context.TestEntities).Filter(searchDefinition);

                var expectedResults = context.TestEntities.Where(i => i.BoolProperty);

                // Assert
                Assert.NotNull(filterResults);
                Assert.NotEmpty(filterResults);
                Assert.Equal(expectedResults.Count(), filterResults.Count());
            }
        }

        [Fact]
        public void Filter_Ignores_Sorting()
        {
            // Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Filter_Ignores_Sorting")
                .Options;

            using (var context = new TestContext(options))
            {
                context.TestEntities.Add(new TestEntity() { BoolProperty = true, IntProperty = 0 });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false, IntProperty = 1 });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true, IntProperty = 2 });
                context.TestEntities.Add(new TestEntity() { BoolProperty = false, IntProperty = 3 });
                context.TestEntities.Add(new TestEntity() { BoolProperty = true, IntProperty = 4 });
                context.SaveChanges();

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.BoolProperty).IsTrue();
                searchDefinition.Sort.DescendingBy(i => i.IntProperty);
                var filterResults = new Searcher<TestEntity>(context.TestEntities).Filter(searchDefinition);

                var expectedResults = context.TestEntities
                    .Where(i => i.BoolProperty)
                    .AsEnumerable();

                // Assert
                Assert.NotNull(filterResults);
                Assert.NotEmpty(filterResults);
                Assert.Equal(expectedResults.Count(), filterResults.Count());
                Assert.Equal(expectedResults.ElementAt(0).IntProperty, filterResults.ElementAt(0).IntProperty);
                Assert.Equal(expectedResults.ElementAt(1).IntProperty, filterResults.ElementAt(1).IntProperty);
                Assert.Equal(expectedResults.ElementAt(2).IntProperty, filterResults.ElementAt(2).IntProperty);
            }
        }
    }
}
