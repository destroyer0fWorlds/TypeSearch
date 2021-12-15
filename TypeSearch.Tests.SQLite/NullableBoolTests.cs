using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.SQLite.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.SQLite
{
    public class NullableBoolTests
    {
        [Fact]
        public void NullableBool_IsEqualTo_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).IsEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_IsNotEqualTo_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).IsNotEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(5, searchResults.ResultSet.Count);
                Assert.Equal(5, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_In_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).In(new bool?[] { null });
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_NotIn_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).NotIn(new bool?[] { null });
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(5, searchResults.ResultSet.Count);
                Assert.Equal(5, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_IsTrue_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).IsTrue();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_IsFalse_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).IsFalse();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_IsNull_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).IsNull();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_IsNotNull_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).IsNotNull();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(5, searchResults.ResultSet.Count);
                Assert.Equal(5, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_IsEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).IsEqualTo(true);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_IsNotEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).IsNotEqualTo(true);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(4, searchResults.ResultSet.Count);
                Assert.Equal(4, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_In_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).In(true);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_NotIn_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).NotIn(true);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(4, searchResults.ResultSet.Count);
                Assert.Equal(4, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_Contains_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).Contains("ru");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_DoesNotContain_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).DoesNotContain("ru");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(4, searchResults.ResultSet.Count);
                Assert.Equal(4, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_StartsWith_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).StartsWith("t");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_DoesNotStartWith_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).DoesNotStartWith("t");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(4, searchResults.ResultSet.Count);
                Assert.Equal(4, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_EndsWith_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).EndsWith("ue");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableBool_DoesNotEndWith_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableBoolProperty).DoesNotEndWith("ue");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(4, searchResults.ResultSet.Count);
                Assert.Equal(4, searchResults.FilteredRecordCount);
            }
        }

        TestContext GetTestContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite()
                .Options;

            var dbName = $"TypeSearch_UnitTests_SQLite_{nameof(NullableBoolTests)}";
            var db = new TestContext(options, dbName);

            db.Database.EnsureCreated();

            // Ensure the db has records in it before attempting to search
            var testEntity = db.TestEntities.FirstOrDefault();
            if (testEntity == null)
            {
                db.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                db.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                db.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                db.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                db.TestEntities.Add(new TestEntity() { NullableBoolProperty = false });
                db.TestEntities.Add(new TestEntity() { NullableBoolProperty = null });
                db.TestEntities.Add(new TestEntity() { NullableBoolProperty = true });
                db.SaveChanges();
            }

            return db;
        }
    }
}
