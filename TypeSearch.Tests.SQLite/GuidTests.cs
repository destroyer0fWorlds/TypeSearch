using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.SQLite.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.SQLite
{
    public class GuidTests
    {
        [Fact]
        public void Guid_IsEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.GuidProperty).IsEqualTo(new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7"));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(5, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.ResultSet.Count);
                Assert.Equal(1, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Guid_IsNotEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.GuidProperty).IsNotEqualTo(new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7"));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(5, searchResults.TotalRecordCount);
                Assert.Equal(4, searchResults.ResultSet.Count);
                Assert.Equal(4, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Guid_In_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.GuidProperty).In(new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B"), new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5"));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(5, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Guid_NotIn_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.GuidProperty).NotIn(new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B"), new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5"));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(5, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        TestContext GetTestContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite()
                .Options;

            var dbName = $"TypeSearch_UnitTests_SQLite_{nameof(GuidTests)}";
            var db = new TestContext(options, dbName);

            db.Database.EnsureCreated();

            // Ensure the db has records in it before attempting to search
            var testEntity = db.TestEntities.FirstOrDefault();
            if (testEntity == null)
            {
                db.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B") });
                db.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("F5A9D2E2-B8E6-4BA8-8E24-1F0201D84283") });
                db.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7") });
                db.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("873EAD6C-48CD-4457-99E1-00295D004857") });
                db.TestEntities.Add(new TestEntity() { GuidProperty = new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") });
                db.SaveChanges();
            }

            return db;
        }
    }
}
