using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.SQLite.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.SQLite
{
    public class NullableDateTimeTests
    {
        [Fact]
        public void NullableDateTime_IsEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).IsEqualTo(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.ResultSet.Count);
                Assert.Equal(1, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_IsNotEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).IsNotEqualTo(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(6, searchResults.ResultSet.Count);
                Assert.Equal(6, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_In_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                var two = new DateTime(2004, 6, 10);
                var three = new DateTime(2007, 7, 21);
                var four = new DateTime(2012, 9, 15);

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).In(two, three, four);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_NotIn_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                var two = new DateTime(2004, 6, 10);
                var three = new DateTime(2007, 7, 21);
                var four = new DateTime(2012, 9, 15);

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).NotIn(two, three, four);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(4, searchResults.ResultSet.Count);
                Assert.Equal(4, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_GreaterThan_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).GreaterThan(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_GreaterThanOrEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).GreaterThanOrEqualTo(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_LessThan_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).LessThan(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(4, searchResults.FilteredRecordCount);
                Assert.Equal(4, searchResults.ResultSet.Count);
            }
        }

        [Fact]
        public void NullableDateTime_LessThanOrEqualTo_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).LessThanOrEqualTo(new DateTime(2007, 7, 21));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(5, searchResults.ResultSet.Count);
                Assert.Equal(5, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_Between_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).Between(new DateTime(2004, 6, 10), new DateTime(2012, 9, 15));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(3, searchResults.ResultSet.Count);
                Assert.Equal(3, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_NotBetween_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter
                    .Where(i => i.NullableDateTimeProperty).NotBetween(new DateTime(2004, 6, 10), new DateTime(2012, 9, 15));
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_IsEqualTo_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).IsEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_IsNotEqualTo_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).IsNotEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(5, searchResults.ResultSet.Count);
                Assert.Equal(5, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_IsNull_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).IsNull();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_IsNotNull_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).IsNotNull();
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(5, searchResults.ResultSet.Count);
                Assert.Equal(5, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_In_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                var two = new DateTime(2004, 6, 10);
                var three = new DateTime(2007, 7, 21);
                var four = new DateTime(2012, 9, 15);

                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).In(new DateTime?[] { null });
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_NotIn_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).NotIn(new DateTime?[] { null });
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(5, searchResults.ResultSet.Count);
                Assert.Equal(5, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_GreaterThan_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).GreaterThan(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(5, searchResults.ResultSet.Count);
                Assert.Equal(5, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_GreaterThanOrEqualTo_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).GreaterThanOrEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(7, searchResults.ResultSet.Count);
                Assert.Equal(7, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_LessThan_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).LessThan(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_LessThanOrEqualTo_Null_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).LessThanOrEqualTo(null);
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(2, searchResults.ResultSet.Count);
                Assert.Equal(2, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_Contains_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).Contains("2007");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.ResultSet.Count);
                Assert.Equal(1, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_DoesNotContain_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).DoesNotContain("2007");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(6, searchResults.ResultSet.Count);
                Assert.Equal(6, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_StartsWith_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).StartsWith("2007");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(1, searchResults.ResultSet.Count);
                Assert.Equal(1, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_DoesNotStartWith_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).DoesNotStartWith("2007");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(6, searchResults.ResultSet.Count);
                Assert.Equal(6, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_EndsWith_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).EndsWith("PM");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(0, searchResults.ResultSet.Count);
                Assert.Equal(0, searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void NullableDateTime_DoesNotEndWith_Search()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>();
                searchDefinition.Filter.Where(i => i.NullableDateTimeProperty).DoesNotEndWith("PM");
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(7, searchResults.TotalRecordCount);
                Assert.Equal(7, searchResults.ResultSet.Count);
                Assert.Equal(7, searchResults.FilteredRecordCount);
            }
        }

        TestContext GetTestContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite()
                .Options;

            var dbName = $"TypeSearch_UnitTests_SQLite_{nameof(NullableDateTimeTests)}";
            var db = new TestContext(options, dbName);

            db.Database.EnsureCreated();

            // Ensure the db has records in it before attempting to search
            var testEntity = db.TestEntities.FirstOrDefault();
            if (testEntity == null)
            {
                db.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                db.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2000, 4, 12) });
                db.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2004, 6, 10) });
                db.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2007, 7, 21) });
                db.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2012, 9, 15) });
                db.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = new DateTime(2016, 11, 7) });
                db.TestEntities.Add(new TestEntity() { NullableDateTimeProperty = null });
                db.SaveChanges();
            }

            return db;
        }
    }
}
