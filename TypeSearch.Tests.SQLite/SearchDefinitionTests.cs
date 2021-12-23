using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TypeSearch.Tests.SQLite.Mocks;
using TypeSearch.Providers.EFCore;

namespace TypeSearch.Tests.SQLite
{
    public class SearchDefinitionTests
    {
        [Fact]
        public void SearchDefinition_New_Definition()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(new SearchDefinition<TestEntity>());

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void SearchDefinition_Null_Definition()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(null);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void SearchDefinition_Empty_Criteria()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>()
                {
                    Filter = new FilterCriteria<TestEntity>(),
                    PreFilter = new FilterCriteria<TestEntity>(),
                    Sort = new SortCriteria<TestEntity>()
                };
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void SearchDefinition_Null_Criteria()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>()
                {
                    Filter = null,
                    PreFilter = null,
                    Sort = null
                };
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void SearchDefinition_Paging_No_Page_Specified()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>() { RecordsPerPage = 1 };
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Null(searchResults.Page);
                Assert.Equal(1, searchResults.RecordsPerPage);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void SearchDefinition_Paging_No_RecordsPerPage_Specified()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>() { Page = 1 };
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(1, searchResults.Page);
                Assert.Null(searchResults.RecordsPerPage);
                Assert.Equal(context.TestEntities.Count(), searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void SearchDefinition_Paging_Page_And_RecordsPerPage_Too_High()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>() { Page = 9, RecordsPerPage = 50 };
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(9, searchResults.Page);
                Assert.Equal(50, searchResults.RecordsPerPage);
                Assert.Empty(searchResults.ResultSet);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void SearchDefinition_Paging_Page_And_RecordsPerPage_Too_Low()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act
                var searchDefinition = new SearchDefinition<TestEntity>() { Page = -7, RecordsPerPage = -49 };
                var searchResults = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition);

                var expectedResults = context.TestEntities
                    .Skip(-7 * -49)
                    .Take(-49)
                    .ToList();

                // Assert
                Assert.NotNull(searchResults.ResultSet);
                Assert.Equal(-7, searchResults.Page);
                Assert.Equal(-49, searchResults.RecordsPerPage);
                Assert.Equal(expectedResults.Count, searchResults.ResultSet.Count);
                Assert.Equal(context.TestEntities.Count(), searchResults.FilteredRecordCount);
            }
        }

        [Fact]
        public void SearchDefinition_Paging_Does_Not_Duplicate_Or_Skip_Any_Records()
        {
            // Arrange
            using (var context = this.GetTestContext())
            {
                // Act

                // 0-50
                var searchDefinition1 = new SearchDefinition<TestEntity>() { Page = 0, RecordsPerPage = 50 };
                var searchResults1 = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition1);

                // 51-100
                var searchDefinition2 = new SearchDefinition<TestEntity>() { Page = 1, RecordsPerPage = 50 };
                var searchResults2 = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition2);

                // 101-150
                var searchDefinition3 = new SearchDefinition<TestEntity>() { Page = 2, RecordsPerPage = 50 };
                var searchResults3 = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition3);

                // 151-200
                var searchDefinition4 = new SearchDefinition<TestEntity>() { Page = 3, RecordsPerPage = 50 };
                var searchResults4 = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition4);

                // 201-250
                var searchDefinition5 = new SearchDefinition<TestEntity>() { Page = 4, RecordsPerPage = 50 };
                var searchResults5 = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition5);

                // 251-300
                var searchDefinition6 = new SearchDefinition<TestEntity>() { Page = 5, RecordsPerPage = 50 };
                var searchResults6 = new EFCoreSearcher<TestEntity>(context.TestEntities).Search(searchDefinition6);
                
                var recombinedDataset = new List<TestEntity>();
                recombinedDataset.AddRange(searchResults1.ResultSet);
                recombinedDataset.AddRange(searchResults2.ResultSet);
                recombinedDataset.AddRange(searchResults3.ResultSet);
                recombinedDataset.AddRange(searchResults4.ResultSet);
                recombinedDataset.AddRange(searchResults5.ResultSet);
                recombinedDataset.AddRange(searchResults6.ResultSet);

                // Assert
                Assert.Equal(context.TestEntities.Count(), recombinedDataset.Count);
            }
        }

        TestContext GetTestContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlite()
                .Options;

            var dbName = $"TypeSearch_UnitTests_SQLite_{nameof(SearchDefinitionTests)}";
            var db = new TestContext(options, dbName);

            db.Database.EnsureCreated();

            // Ensure the db has records in it before attempting to search
            var testEntity = db.TestEntities.FirstOrDefault();
            if (testEntity == null)
            {
                for (int i = 0; i < 300; i++)
                {
                    db.TestEntities.Add(new TestEntity() { IntProperty = i });
                }
                db.SaveChanges();
            }

            return db;
        }
    }
}
