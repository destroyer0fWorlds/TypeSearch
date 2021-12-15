using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.SQLite.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.SQLite
{
    public class FilterTests
    {
        [Fact]
        public void Filter_Ignores_Paging()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>(page: 3, recordsPerPage: 1);
                searchDefinition.Filter.Where(i => i.BoolProperty).IsTrue();
                var filterResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Filter(searchDefinition);

                // Assert
                Assert.NotNull(filterResults);
                Assert.NotEmpty(filterResults);
                Assert.Equal(3, filterResults.Count());
            }
        }

        [Fact]
        public void Filter_Ignores_Sorting()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.BoolProperty).IsTrue();
                searchDefinition.Sort.DescendingBy(i => i.IntProperty);
                var filterResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Filter(searchDefinition);

                // Assert
                Assert.NotNull(filterResults);
                Assert.NotEmpty(filterResults);
                Assert.Equal(3, filterResults.Count());
                Assert.Equal(1, filterResults.ElementAt(0).IntProperty);
                Assert.Equal(3, filterResults.ElementAt(1).IntProperty);
                Assert.Equal(5, filterResults.ElementAt(2).IntProperty);
            }
        }

        TestContext GetTestContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite()
                .Options;

            var dbName = $"TypeSearch_UnitTests_SQLite_{nameof(FilterTests)}";
            var db = new TestContext(options, dbName);

            db.Database.EnsureCreated();

            // Ensure the db has records in it before attempting to search
            var testEntity = db.TestEntities.FirstOrDefault();
            if (testEntity == null)
            {
                db.TestEntities.Add(new TestEntity() { IntProperty = 1, BoolProperty = true });
                db.TestEntities.Add(new TestEntity() { IntProperty = 2, BoolProperty = false });
                db.TestEntities.Add(new TestEntity() { IntProperty = 3, BoolProperty = true });
                db.TestEntities.Add(new TestEntity() { IntProperty = 4, BoolProperty = false });
                db.TestEntities.Add(new TestEntity() { IntProperty = 5, BoolProperty = true });
                db.SaveChanges();
            }

            return db;
        }
    }
}
