using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.SQLite.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.SQLite
{
    public class NumberTests
    {
        [Fact]
        public void Int_IsEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.IntProperty).IsEqualTo(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(15, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.ResultSet.Count);
                Assert.Equal(1, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_IsNotEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.IntProperty).IsNotEqualTo(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(15, searchResults.TotalRecordCount);
                Assert.Equal(14, searchResults.ResultSet.Count);
                Assert.Equal(14, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_In_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.IntProperty).In(1, 2, 3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(15, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_NotIn_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.IntProperty).NotIn(1, 2, 3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(15, searchResults.TotalRecordCount);
                Assert.Equal(12, searchResults.ResultSet.Count);
                Assert.Equal(12, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_GreaterThan_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.IntProperty).GreaterThan(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(15, searchResults.TotalRecordCount);
                Assert.Equal(12, searchResults.ResultSet.Count);
                Assert.Equal(12, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_GreaterThanOrEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.IntProperty).GreaterThanOrEqualTo(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(15, searchResults.TotalRecordCount);
                Assert.Equal(13, searchResults.ResultSet.Count);
                Assert.Equal(13, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_LessThan_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.IntProperty).LessThan(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(15, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_LessThanOrEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.IntProperty).LessThanOrEqualTo(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(15, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_Between_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.IntProperty).Between(2, 4);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(15, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void Int_NotBetween_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.IntProperty).NotBetween(2, 4);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(15, searchResults.TotalRecordCount);
                Assert.Equal(13, searchResults.ResultSet.Count);
                Assert.Equal(13, searchResults.FilteredRecordCount);
            }
        }

        TestContext GetTestContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite()
                .Options;

            var dbName = $"TypeSearch_UnitTests_SQLite_{nameof(NumberTests)}";
            var db = new TestContext(options, dbName);

            db.Database.EnsureCreated();

            // Ensure the db has records in it before attempting to search
            var testEntity = db.TestEntities.FirstOrDefault();
            if (testEntity == null)
            {
                db.TestEntities.Add(new TestEntity() { IntProperty = 1 });
                db.TestEntities.Add(new TestEntity() { IntProperty = 12 });
                db.TestEntities.Add(new TestEntity() { IntProperty = 123 });
                db.TestEntities.Add(new TestEntity() { IntProperty = 1234 });
                db.TestEntities.Add(new TestEntity() { IntProperty = 12345 });
                db.TestEntities.Add(new TestEntity() { IntProperty = 2 });
                db.TestEntities.Add(new TestEntity() { IntProperty = 23 });
                db.TestEntities.Add(new TestEntity() { IntProperty = 234 });
                db.TestEntities.Add(new TestEntity() { IntProperty = 2345 });
                db.TestEntities.Add(new TestEntity() { IntProperty = 23456 });
                db.TestEntities.Add(new TestEntity() { IntProperty = 3 });
                db.TestEntities.Add(new TestEntity() { IntProperty = 34 });
                db.TestEntities.Add(new TestEntity() { IntProperty = 345 });
                db.TestEntities.Add(new TestEntity() { IntProperty = 3456 });
                db.TestEntities.Add(new TestEntity() { IntProperty = 3457 });
                db.SaveChanges();
            }

            return db;
        }
    }
}
