using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.SQLite.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.SQLite
{
    public class NullableNumberTests
    {
        [Fact]
        public void NullableInt_IsEqualTo_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).IsEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_IsNotEqualTo_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).IsNotEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(15, searchResults.ResultSet.Count);
                Assert.Equal(15, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_In_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).In(new int?[] { null });
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_NotIn_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).NotIn(new int?[] { null });
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(15, searchResults.ResultSet.Count);
                Assert.Equal(15, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_IsNull_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).IsNull();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_IsNotNull_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).IsNotNull();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(15, searchResults.ResultSet.Count);
                Assert.Equal(15, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_GreaterThan_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).GreaterThan(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(15, searchResults.ResultSet.Count);
                Assert.Equal(15, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_GreaterThanOrEqualTo_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).GreaterThanOrEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(18, searchResults.ResultSet.Count);
                Assert.Equal(18, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_LessThan_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).LessThan(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(0, searchResults.ResultSet.Count);
                Assert.Equal(0, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_LessThanOrEqualTo_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).LessThanOrEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_IsEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).IsEqualTo(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.ResultSet.Count);
                Assert.Equal(1, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_IsNotEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).IsNotEqualTo(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(17, searchResults.ResultSet.Count);
                Assert.Equal(17, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_In_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).In(2, 3, 4);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_NotIn_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).NotIn(2, 3, 4);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(15, searchResults.ResultSet.Count);
                Assert.Equal(15, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_GreaterThan_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).GreaterThan(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(12, searchResults.ResultSet.Count);
                Assert.Equal(12, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_GreaterThanOrEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).GreaterThanOrEqualTo(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(13, searchResults.ResultSet.Count);
                Assert.Equal(13, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_LessThan_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).LessThan(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(5, searchResults.ResultSet.Count);
                Assert.Equal(5, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_LessThanOrEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).LessThanOrEqualTo(3);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(6, searchResults.ResultSet.Count);
                Assert.Equal(6, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_Between_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).Between(2, 4);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.ResultSet.Count);
                Assert.Equal(1, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableInt_NotBetween_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableIntProperty).NotBetween(2, 4);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(18, searchResults.TotalRecordCount);
                Assert.Equal(17, searchResults.ResultSet.Count);
                Assert.Equal(17, searchResults.FilteredRecordCount);
            }
        }

        TestContext GetTestContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite()
                .Options;

            var dbName = $"TypeSearch_UnitTests_SQLite_{nameof(NullableNumberTests)}";
            var db = new TestContext(options, dbName);

            db.Database.EnsureCreated();

            // Ensure the db has records in it before attempting to search
            var testEntity = db.TestEntities.FirstOrDefault();
            if (testEntity == null)
            {
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = 1 });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = 12 });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = 123 });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = 1234 });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = 12345 });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = 2 });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = 23 });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = 234 });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = 2345 });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = 23456 });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = 3 });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = 34 });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = 345 });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = 3456 });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = 3457 });
                db.TestEntities.Add(new TestEntity() { NullableIntProperty = null });
                db.SaveChanges();
            }

            return db;
        }
    }
}
