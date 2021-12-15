using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.SQLite.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.SQLite
{
    public class NullableGuidTests
    {
        [Fact]
        public void NullableGuid_IsEqualTo_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableGuidProperty).IsEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(8, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_IsNotEqualTo_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableGuidProperty).IsNotEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(8, searchResults.TotalRecordCount);
                Assert.Equal(5, searchResults.ResultSet.Count);
                Assert.Equal(5, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_In_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableGuidProperty).In(new Guid?[] { null });
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(8, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_NotIn_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableGuidProperty).NotIn(new Guid?[] { null });
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(8, searchResults.TotalRecordCount);
                Assert.Equal(5, searchResults.ResultSet.Count);
                Assert.Equal(5, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_IsNull_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableGuidProperty).IsNull();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(8, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_IsNotNull_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableGuidProperty).IsNotNull();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(8, searchResults.TotalRecordCount);
                Assert.Equal(5, searchResults.FilteredRecordCount);
                Assert.Equal(5, searchResults.ResultSet.Count);
            }
        }

        [Fact]
        public void NullableGuid_IsEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableGuidProperty).IsEqualTo(new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7"));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(8, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.ResultSet.Count);
                Assert.Equal(1, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_IsNotEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableGuidProperty).IsNotEqualTo(new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7"));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(8, searchResults.TotalRecordCount);
                Assert.Equal(7, searchResults.ResultSet.Count);
                Assert.Equal(7, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_In_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableGuidProperty).In(new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B"), new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5"));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(8, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableGuid_NotIn_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableGuidProperty).NotIn(new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B"), new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5"));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(8, searchResults.TotalRecordCount);
                Assert.Equal(6, searchResults.ResultSet.Count);
                Assert.Equal(6, searchResults.FilteredRecordCount);
            }
        }

        TestContext GetTestContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite()
                .Options;

            var dbName = $"TypeSearch_UnitTests_SQLite_{nameof(NullableGuidTests)}";
            var db = new TestContext(options, dbName);

            db.Database.EnsureCreated();

            // Ensure the db has records in it before attempting to search
            var testEntity = db.TestEntities.FirstOrDefault();
            if (testEntity == null)
            {
                db.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("AF135DF9-5DEA-414C-ADCB-BF743ADC129B") });
                db.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                db.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F5A9D2E2-B8E6-4BA8-8E24-1F0201D84283") });
                db.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("F55FF70A-9C4C-4F48-84B3-04DDB4B83BB7") });
                db.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("873EAD6C-48CD-4457-99E1-00295D004857") });
                db.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                db.TestEntities.Add(new TestEntity() { NullableGuidProperty = new Guid("66EFCE02-AC2D-414A-8AB1-F74E07EE83E5") });
                db.TestEntities.Add(new TestEntity() { NullableGuidProperty = null });
                db.SaveChanges();
            }

            return db;
        }
    }
}
